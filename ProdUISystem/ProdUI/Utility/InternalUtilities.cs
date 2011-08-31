/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Automation;
using ProdUI.Controls;
using ProdUI.Exceptions;
using System.Collections.Generic;

namespace ProdUI.Utility
{
    [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
    internal static class InternalUtilities
    {
        #region Fields

        /// <summary>
        ///   key = handle (IntPtr) ; value = title (string)
        /// </summary>
        internal static Hashtable WindowList;

        /// <summary>
        ///   List of all child windows and their handles
        /// </summary>
        internal static Hashtable ChildList;

        #endregion

        #region Callbacks

        /// <summary>
        ///   An application-defined callback function used with the EnumWindows or EnumDesktopWindows function.
        ///   It receives top-level window handles
        /// </summary>
        /// <param name = "windowHandle">A handle to a top-level window.</param>
        /// <param name = "lParam">nothing in this case</param>
        /// <returns>
        ///   To continue enumeration, the callback function must return TRUE;
        ///   to stop enumeration, it must return FALSE
        /// </returns>
        internal static bool EnumWindowsProc(IntPtr windowHandle, int lParam)
        {
            StringBuilder winText = new StringBuilder(256);
            if (!NativeMethods.IsWindowVisible(windowHandle))
            {
                return true;
            }
            if (NativeMethods.GetWindowText(windowHandle, winText, winText.Capacity) == 0)
            {
                return true;
            }

            if (winText.Length > 0)
            {
                WindowList.Add(windowHandle, winText.ToString());
            }
            return true;
        }

        /// <summary>
        ///   Used with the EnumChildWindows function. It receives the child window handles.
        /// </summary>
        /// <param name = "windowHandle">A handle to a child window of the parent window specified in EnumChildWindows</param>
        /// <param name = "lParam">The application-defined value given in EnumChildWindows</param>
        /// <returns>
        ///   to continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE
        /// </returns>
        internal static bool EnumChildProc(IntPtr windowHandle, int lParam)
        {
            StringBuilder winText = new StringBuilder(256);

            if (NativeMethods.GetWindowText(windowHandle, winText, winText.Capacity) == 0)
            {
                return true;
            }
            if (winText.Length > 0)
            {
                ChildList.Add(windowHandle, winText.ToString());
                return false;
            }
            return true;
        }

        #endregion

        #region Top-Level Window Functions

        /// <summary>
        ///   Used for call from WinWaitExists
        /// </summary>
        /// <param name = "thePartialTitle">The partial title.</param>
        /// <returns></returns>
        internal static IntPtr WinWaitSearch(string thePartialTitle)
        {
            IntPtr retPtr = NativeMethods.FindWindow(null, thePartialTitle);

            if (retPtr == IntPtr.Zero)
            {
                WindowList = new Hashtable();
                NativeMethods.EnumDesktopWindows(IntPtr.Zero, EnumWindowsProc, IntPtr.Zero);
                foreach (DictionaryEntry de in WindowList)
                {
                    if (de.Value.ToString().Contains(thePartialTitle))
                    {
                        return (IntPtr) de.Key;
                    }
                }
                return IntPtr.Zero;
            }

            return retPtr;
        }

        /// <summary>
        ///   Gets a table of handles/titles. searches table for first instance of title that contains text
        /// </summary>
        /// <param name = "thePartialTitle">the initial part of, or an entire, window name</param>
        /// <returns>the handle to the window, or zero pointer if not found</returns>
        internal static IntPtr FindWindowPartial(string thePartialTitle)
        {
            WindowList = new Hashtable();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (p.MainWindowTitle.Contains(thePartialTitle))
                {
                    return p.MainWindowHandle;
                }
            }

            if (NativeMethods.FindWindow(null, thePartialTitle) == IntPtr.Zero)
            {
                NativeMethods.EnumDesktopWindows(IntPtr.Zero, EnumWindowsProc, IntPtr.Zero);
                return EnumerateExistingWindowsPartial(thePartialTitle);
            }
            return IntPtr.Zero;
        }

        /// <summary>
        ///   Enumerates the existing windows Hashtable using partial title.
        /// </summary>
        /// <param name = "thePartialTitle">The partial title.</param>
        /// <returns></returns>
        private static IntPtr EnumerateExistingWindowsPartial(string thePartialTitle)
        {
            foreach (DictionaryEntry de in WindowList)
            {
                if (de.Value.ToString().Contains(thePartialTitle))
                {
                    return (IntPtr) de.Key;
                }
            }

            return IntPtr.Zero;
        }

        #endregion

        #region Child Window Functions

        /// <summary>
        ///   Enumerates child windows and fills the Hashtable
        /// </summary>
        /// <param name = "theParentHandle">Handle to the parent window</param>
        /// <param name = "theChildTitle">The text associated with the desired child control</param>
        /// <returns>the handle to the window, or zero pointer if not found</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available <seealso cref = "ElementNotAvailableException" /></exception>
        internal static IntPtr GetChildWindow(IntPtr theParentHandle, string theChildTitle)
        {
            if ((int) theParentHandle == 0)
            {
                throw new ProdOperationException("Handle Not found", new ElementNotAvailableException());
            }

            IntPtr retVal = NativeMethods.FindWindowEX(theParentHandle, IntPtr.Zero, null, theChildTitle);
            if (retVal == IntPtr.Zero)
            {
                /* heres another method, just in case */
                ChildList = new Hashtable();
                NativeMethods.EnumChildWindows(theParentHandle, EnumChildProc, IntPtr.Zero);
                return EnumerateExistingChildren(theChildTitle);
            }

            return retVal;
        }

        /// <summary>
        ///   finds window handle of control with corresponding ID
        /// </summary>
        /// <param name = "theParentHandle">Handle to the window containing the control</param>
        /// <param name = "controlId">Resource Id of the control</param>
        /// <returns>Handle to the window if successful, 0 if not</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available <seealso cref = "ElementNotAvailableException" /></exception>
        public static IntPtr GetChildHandle(IntPtr theParentHandle, int controlId)
        {
            if ((int) theParentHandle == 0)
            {
                throw new ProdOperationException("Handle Not found", new ElementNotAvailableException());
            }
            IntPtr inp = IntPtr.Zero;
            ChildList = new Hashtable();
            NativeMethods.EnumChildWindows(theParentHandle, EnumChildProc, IntPtr.Zero);
            foreach (DictionaryEntry item in ChildList)
            {
                inp = NativeMethods.GetDlgItem(NativeMethods.GetParent((IntPtr) item.Key), controlId);
                if (inp != IntPtr.Zero)
                {
                    break;
                }
            }
            return inp;
        }

        /// <summary>
        ///   Gets control handle that contains the specified text
        /// </summary>
        /// <param name = "theParentHandle">Handle to the window containing the control</param>
        /// <param name = "theControlText">The text to match</param>
        /// <returns>Handle to the window if successful, 0 if not</returns>
        /// <exception cref = "ProdOperationException">Thrown if call is invalid for the object's current state <seealso cref = "InvalidOperationException" /></exception>
        public static IntPtr GetChildHandle(IntPtr theParentHandle, string theControlText)
        {
            AutomationElement control;

            if ((int) theParentHandle == 0)
            {
                throw new ProdOperationException("Handle Not found", new ElementNotAvailableException());
            }


            /* try the automation ID */
            try
            {
                AutomationElement mainWin = AutomationElement.FromHandle(theParentHandle);

                AndCondition ourElement = new AndCondition(new PropertyCondition(AutomationElement.NameProperty, theControlText, PropertyConditionFlags.IgnoreCase), new PropertyCondition(AutomationElement.IsContentElementProperty, true));
                control = mainWin.FindFirst(TreeScope.Descendants, ourElement);

                if (control == null)
                {
                    AndCondition automationId = new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, theControlText, PropertyConditionFlags.IgnoreCase), new PropertyCondition(AutomationElement.IsContentElementProperty, true));
                    control = mainWin.FindFirst(TreeScope.Descendants, automationId);
                }

                int retVal = control.Current.NativeWindowHandle;

                if (retVal == 0)
                {
                    IntPtr ptr = GetChildWindow(theParentHandle, theControlText);
                    if (ptr == IntPtr.Zero)
                    {
                        throw new ProdOperationException(new ElementNotAvailableException());
                    }
                    return ptr;
                }

                return (IntPtr) retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Enumerates the existing child windows stored in the ChildList table.
        /// </summary>
        /// <param name = "theChildTitle">The child title.</param>
        /// <returns>Window handle to the matching control</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available <seealso cref = "NullReferenceException" /></exception>
        private static IntPtr EnumerateExistingChildren(string theChildTitle)
        {
            try
            {
                foreach (DictionaryEntry de in ChildList)
                {
                    if (de.Value.ToString().Contains(theChildTitle))
                    {
                        return (IntPtr) de.Key;
                    }
                }
            }
            catch (NullReferenceException err)
            {
                throw new ProdOperationException(err.Message, err);
            }

            return IntPtr.Zero;
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///   Convenience method used to convert from an AutomationElementCollection to an object collection
        /// </summary>
        /// <param name = "ret">AutomationElementCollection to be converted</param>
        /// <returns>converted collection</returns>
        internal static ArrayList AutomationCollToArrayList(AutomationElementCollection ret)
        {
            ArrayList retColl = new ArrayList();

            foreach (AutomationElement item in ret)
            {
                retColl.Add(item.Current.Name);
            }
            return retColl;
        }

        /// <summary>
        ///   Convenience method used to convert from an AutomationElementCollection to an object collection
        /// </summary>
        /// <param name = "ret">AutomationElementCollection to be converted</param>
        /// <returns>converted collection</returns>
        internal static List<object> AutomationCollToObjectList(AutomationElementCollection ret)
        {
            List<object> retColl = new List<object>() {ret};

            //foreach (AutomationElement item in ret)
            //{
            //    retColl.Add(item.Current.Name);
            //}
            return retColl;
        }

        /// <summary>Converts the string to send key.</summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        /// <remarks>Converts from format of "Shift+CTRL+Y" into "+^(Y)"</remarks>
        internal static string ConvertStringToSendKey(string keys)
        {
            string[] accel = keys.Split('+');
            string finalAccel = string.Empty;

            foreach (string t in accel)
            {
                if (t == "SHIFT")
                {
                    finalAccel+=  "+";
                    continue;
                }
                if (t == "CTRL")
                {
                    finalAccel += "^";
                    continue;
                }
                if (t == "Alt")
                {
                    finalAccel += "%";
                    continue;
                }
                finalAccel += "(" + t;
            }
            finalAccel += ")";

            return finalAccel;
        }

        #endregion

        /// <summary>
        ///   Gets the stack trace and converts it into a string collection
        /// </summary>
        /// <param name = "frames">The frames.</param>
        /// <returns>A string collection of the frames content</returns>
        internal static Collection<string> GetStackTrace(StackFrame[] frames)
        {
            Collection<string> retColl = new Collection<string>();

            foreach (StackFrame item in frames)
            {
                retColl.Add(item.ToString());
            }

            return retColl;
        }

        /// <summary>
        ///   Moves the mouse to the specified point.
        /// </summary>
        /// <param name = "pt">The point....</param>
        internal static void MoveMouseToPoint(Point pt)
        {
            SendMouseInput(pt.X, pt.Y, 0, MOUSEEVENTF.MouseeventfMove | MOUSEEVENTF.MouseeventfAbsolute);
        }

        /// <summary>
        /// Inject pointer input into the system - Shamelessley taken from UI Verify - http://uiautomationverify.codeplex.com/
        /// </summary>
        /// <param name="x">x coordinate of pointer, if Move flag specified</param>
        /// <param name="y">y coordinate of pointer, if Move flag specified</param>
        /// <param name="data">wheel movement, or mouse X button, depending on flags</param>
        /// <param name="flags">flags to indicate which type of input occurred - move, button press/release, wheel move, etc.</param>
        /// <exception cref="ProdOperationException">Thrown if Security permissions won't allow execution</exception>
        ///   
        /// <exception cref="Win32Exception">Thrown if SendInput call fails</exception>
        ///   
        /// <outside_see conditional="false">
        /// This API does not work inside the secure execution environment.
        ///   <exception cref="System.Security.Permissions.SecurityPermission"/>
        ///   </outside_see>
        /// <remarks>
        /// x, y are in pixels. If Absolute flag used, are relative to desktop origin.
        /// </remarks>
        internal static void SendMouseInput(double x, double y, int data, MOUSEEVENTF flags)
        {
            int intflags = (int) flags;

            try
            {
                if ((intflags & (int) MOUSEEVENTF.MouseeventfAbsolute) != 0)
                {
                    int vscreenWidth = NativeMethods.GetSystemMetrics((int) SystemMetric.SMCxvirtualscreen);
                    int vscreenHeight = NativeMethods.GetSystemMetrics((int) SystemMetric.SMCyvirtualscreen);
                    int vscreenLeft = NativeMethods.GetSystemMetrics((int) SystemMetric.SMXvirtualscreen);
                    int vscreenTop = NativeMethods.GetSystemMetrics((int) SystemMetric.SMYvirtualscreen);

                    // Absolute input requires that input is in 'normalized' coords - with the entire
                    // desktop being (0,0)...(65535,65536). Need to convert input x,y coords to this
                    // first.
                    //
                    // In this normalized world, any pixel on the screen corresponds to a block of values
                    // of normalized coords - eg. on a 1024x768 screen,
                    // y pixel 0 corresponds to range 0 to 85.333,
                    // y pixel 1 corresponds to range 85.333 to 170.666,
                    // y pixel 2 corresponds to range 170.666 to 256 - and so on.
                    // Doing basic scaling math - (x-top)*65536/Width - gets us the start of the range.
                    // However, because int math is used, this can end up being rounded into the wrong
                    // pixel. For example, if we wanted pixel 1, we'd get 85.333, but that comes out as
                    // 85 as an int, which falls into pixel 0's range - and that's where the pointer goes.
                    // To avoid this, we add on half-a-"screen pixel"'s worth of normalized coords - to
                    // push us into the middle of any given pixel's range - that's the 65536/(Width*2)
                    // part of the formula. So now pixel 1 maps to 85+42 = 127 - which is comfortably
                    // in the middle of that pixel's block.
                    // The key ting here is that unlike points in coordinate geometry, pixels take up
                    // space, so are often better treated like rectangles - and if you want to target
                    // a particular pixel, target its rectangle's midpoint, not its edge.
                    x = ((x - vscreenLeft)*65536)/vscreenWidth + 65536/(vscreenWidth*2);
                    y = ((y - vscreenTop)*65536)/vscreenHeight + 65536/(vscreenHeight*2);

                    intflags |= (int) MOUSEEVENTF.MouseeventfVirtualdesk;
                }


                NPUT mi = new NPUT {Type = (int) InputStructType.InputMouse};
                mi.Union.MouseInput.DX = (int) x;
                mi.Union.MouseInput.DY = (int) y;
                mi.Union.MouseInput.MouseData = data;
                mi.Union.MouseInput.DWFlags = intflags;
                mi.Union.MouseInput.Time = 0;
                mi.Union.MouseInput.DWExtraInfo = new IntPtr(0);

                if (NativeMethods.SendInput(1, ref mi, Marshal.SizeOf(mi)) == 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            catch (Exception e)
            {
                throw new ProdOperationException(e.Message, e);
            }
        }

        /// <summary>
        ///   Gets an AutomationElement based on its container window.
        /// </summary>
        /// <param name = "prodWindow">The prod window.</param>
        /// <param name = "automationId">The automation id.</param>
        /// <returns>Corresponding element if successful, null if not</returns>
        internal static AutomationElement GetHandlelessElement(ProdWindow prodWindow, string automationId)
        {
            Condition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            AutomationElement control = prodWindow.Window.FindFirst(TreeScope.Descendants, cond);

            /* then we'll try the name...who knows? */
            if (control == null)
            {
                /* try the name */
                Condition condName = new PropertyCondition(AutomationElement.NameProperty, automationId, PropertyConditionFlags.IgnoreCase);
                control = prodWindow.Window.FindFirst(TreeScope.Descendants, condName);
            }

            return control;
        }
    }
}