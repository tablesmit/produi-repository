/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Automation;
using System.Xml.Serialization;

namespace MapLib
{
    /// <summary>
    ///   Represents a window control that has been mapped
    /// </summary>
    public class MappedControl
    {
        #region Properties

        /// <summary>
        /// Gets a string containing the class name of the element as assigned by the control developer
        /// </summary>
        /// <value>
        /// The name of the class for this control.
        /// </value>
        [XmlElement("ClassName")]
        [Category("Control"), ReadOnlyAttribute(true), DisplayName(@"Window Class"), Description("The Corresponding ProdUI type")]
        public string ClassName { get; set; }

        /// <summary>
        /// Gets a string containing the UI Automation identifier (ID) for the element
        /// </summary>
        /// <value>
        /// The Automation id.
        /// </value>
        [XmlElement("AutomationId")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Automation Id"), Description("The assigned")]
        public string AutomationId { get; set; }

        /// <summary>
        /// Gets the name of the element
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("Name")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Name"), Description("Text associated with the control")]
        public string Name { get; set; }

        /// <summary>
        /// Gets the ControlType of the element
        /// </summary>
        /// <value>
        /// The ControlType.
        /// </value>
        [XmlElement("ControlType")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Control Type"), Description("The Automation.ControlType of the current control")]
        public string ControlType { get; set; }

        /// <summary>
        /// Gets or sets the control tree position.
        /// </summary>
        /// <value>
        /// The control tree position.
        /// </value>
        [XmlElement("ControlTreePosition")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Control Tree Position"), Description("The position of the control in the current windows control tree.")]
        public int ControlTreePosition { get; set; }

        /// <summary>
        /// Gets the help text associated with the element
        /// </summary>
        /// <value>
        /// The associated help text.
        /// </value>
        [XmlElement("HelpText")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Help Text"), Description("Programmer supplied help-text")]
        public string HelpText { get; set; }

        /// <summary>
        /// Gets a string containing the accelerator key combinations for the element
        /// </summary>
        /// <value>
        /// The accelerator keys.
        /// </value>
        [XmlElement("AcceleratorKey")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Accelerator Key"), Description("Key combination to directly access control")]
        public string AcceleratorKey { get; set; }

        /// <summary>
        /// Gets a string containing the access key character for the element
        /// </summary>
        /// <value>
        /// The access key.
        /// </value>
        [XmlElement("AccessKey")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Access Key"), Description("Key combination to activate control")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets the element that contains the text label for this element
        /// </summary>
        /// <value>
        /// The element that contains the text label for this element.
        /// </value>
        [XmlElement("LabeledBy")]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Labeled By"), Description("The control the serves as this elements label")]
        public string LabeledBy { get; set; }

        /// <summary>
        /// Gets a description of the type of an item
        /// </summary>
        /// <value>
        /// The ItemType of the control.
        /// </value>
        [XmlElement("ItemType")]
        [Browsable(false)]
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the custom id assigned by the user.
        /// </summary>
        /// <value>
        /// The custom (user defined) id.
        /// </value>
        [XmlElement("CustomId")]
        [Browsable(false)]
        public string CustomId { get; set; }


        /********** These are not serialized **********/
        /// <summary>
        /// Gets or sets the Type of the prod control.
        /// </summary>
        /// <value>
        /// The Type of the prod control.
        /// </value>
        [XmlIgnore]
        [Browsable(false)]
        public Type ProdControlType { get; set; }

        /// <summary>
        /// Gets the coordinates of the rectangle that completely encloses the element
        /// </summary>
        [XmlIgnore]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Bounding Rectangle"), Description("Coordinates of rectangle that encloses element. \n{ X, Y, Width, Height }")]
        public Rect ControlRect { get; private set; }

        /// <summary>
        /// Gets or sets the automation element.
        /// </summary>
        /// <value>
        /// The automation element.
        /// </value>
        [XmlIgnore]
        [Browsable(false)]
        public AutomationElement AutoElement { get; private set; }

        /// <summary>
        /// Gets or sets the enabled-state of a control.
        /// </summary>
        /// <value>
        /// The enabled-state of a control.
        /// </value>
        [XmlIgnore]
        [CategoryAttribute("Control-UI Automation"), ReadOnlyAttribute(true), DisplayName(@"Enabled"), Description("Whether the control can accept input")]
        public string Enabled { get; set; }

        /// <summary>
        /// Gets the control handle.
        /// </summary>
        /// <value>
        /// The control handle.
        /// </value>
        [XmlIgnore]
        [CategoryAttribute("Control"), ReadOnlyAttribute(true), DisplayName(@"Handle"), Description("Handle to current control")]
        public int ControlHandle { get; private set; }


        /// <summary>
        /// Gets or sets the available Prod methods for this control.
        /// </summary>
        /// <value>
        /// The available Prod methods.
        /// </value>
        [XmlIgnore]
        [Browsable(false)]
        public List<MethodInfo> AvailableProdMethods { get; set; }

        #endregion

        private Type[] _types;

        internal void LoadControl(AutomationElement control, Type[] types)
        {
            _types = types;

            /* get  all of the controls Automation data */
            AcceleratorKey = control.Current.AcceleratorKey;
            AccessKey = control.Current.AccessKey;
            AutomationId = control.Current.AutomationId;
            AutoElement = control;
            ClassName = control.Current.ClassName;
            ControlRect = control.Current.BoundingRectangle;
            ControlType = control.Current.ControlType.LocalizedControlType;
            Enabled = control.Current.IsEnabled.ToString(CultureInfo.CurrentCulture);
            HelpText = control.Current.HelpText;
            ItemType = control.Current.ItemType;
            Name = control.Current.Name;
            ControlHandle = control.Current.NativeWindowHandle;

            CustomId = string.Empty;

            /* reflect to get available Prods for this control type */
            GetAvailableProds();

            if (control.Current.LabeledBy != null)
                LabeledBy = control.Current.LabeledBy.Current.AutomationId;
        }

        /// <summary>
        /// Compares a loaded map to the supplied map file
        /// </summary>
        /// <param name="loadedMap">The loaded map.</param>
        /// <returns>
        /// The list of compare results for each comparison
        /// </returns>
        public List<CompareResult> CompareTo(MappedControl loadedMap)
        {
            return MappedControlComparer.Compare(this, loadedMap);
        }

        /// <summary>
        /// Gets the available Prods for this control.
        /// </summary>
        /// <returns>
        /// A MethodInfo array of all ProdUI Prods available for this control
        /// </returns>
        public List<MethodInfo> GetAvailableProds()
        {
            if (_types == null)
            {
                return null;
            }

            string control = "prod" + ControlType;
            control = control.Replace(" ", "");

            /* Get only instance methods */
            foreach (Type type in _types)
            {
                if (String.Compare(type.Name, control, true, CultureInfo.CurrentCulture) != 0)
                {
                    continue;
                }

                ProdControlType = type.UnderlyingSystemType;
                AvailableProdMethods = new List<MethodInfo>(type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance));
                break;
            }

            return AvailableProdMethods;
        }

    }
}