// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.Utility
{
    internal class ControlTree
    {
        private readonly Collection<AutomationElement> _controls;
        private readonly IntPtr _rootHandle;

        /// <summary>
        ///     Initializes a new instance of the <see cref = "ControlTree" /> class.
        /// </summary>
        /// <param name = "controlHandle">The control handle to the main window.</param>
        internal ControlTree(IntPtr controlHandle)
        {
            /* break over to process */
            _controls = new Collection<AutomationElement>();
            _rootHandle = controlHandle;
            LoadControlTree();
        }

        /// <summary>
        ///     Finds the specified control position.
        /// </summary>
        /// <param name = "controlPosition">The control position.</param>
        /// <returns>
        ///     the corresponding controls window handle
        /// </returns>
        internal int Find(int controlPosition)
        {
            try
            {
                return _controls[controlPosition].Current.NativeWindowHandle;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Finds the element based on its index in the UI Control tree.
        /// </summary>
        /// <param name = "controlPosition">The control position in the tree.</param>
        /// <returns>
        ///     The specified element
        /// </returns>
        internal AutomationElement FindElement(int controlPosition)
        {
            return _controls[controlPosition];
        }

        /// <summary>
        ///     Loads the control tree.
        /// </summary>
        private void LoadControlTree()
        {
            if ((int)_rootHandle == 0)
            {
                return;
            }
            AutomationElement root = AutomationElement.FromHandle(_rootHandle);

            EnumControlElements(root);
        }

        /// <summary>
        ///     Enumerates the elements in the UI Control Tree.
        /// </summary>
        /// <param name = "aeRoot">The root AutomationElement.</param>
        private void EnumControlElements(AutomationElement aeRoot)
        {
            AutomationElement aeNode = TreeWalker.ControlViewWalker.GetFirstChild(aeRoot);

            while (aeNode != null)
            {
                _controls.Add(aeNode);
                EnumControlElements(aeNode);
                aeNode = TreeWalker.ControlViewWalker.GetNextSibling(aeNode);
            }
        }
    }
}