// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Text;

//TODO: not fully implemented

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Handles the TextPattern (for ControlType.Document). implements ITextProvider, ITextRangeProvider
    /// </summary>
    internal static class TextPatternHelper
    {
        internal static object GetTextAttribute(AutomationElement control, AutomationTextAttribute attribute)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            object retVal = pat.DocumentRange.GetAttributeValue(attribute);

            return retVal;
        }

        internal static TextPatternRange[] GetSelection(AutomationElement control)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.GetSelection();
        }

        #region ITextProvider Implementation

        /// <summary>
        ///     gets the Document range.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns></returns>
        internal static TextPatternRange GetDocumentRange(AutomationElement control)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            if (pat == null)
            {
                return null;
            }

            return pat.DocumentRange;
        }

        /// <summary>
        ///     Gets a value that specifies whether a text provider supports selection and, if so, the type of selection supported
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     <see cref = "SupportedTextSelection" /> None, Single, or Multiple
        /// </returns>
        internal static SupportedTextSelection GetSupportedTextSelection(AutomationElement control)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.SupportedTextSelection;
        }

        /// <summary>
        ///     Returns the plain text of the text range.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range.</param>
        /// <param name = "maxLength">The maximum length of the string to return. Use -1 if no limit is required.</param>
        /// <returns>
        ///     The plain text of the text range, possibly truncated at the specified maxLength
        /// </returns>
        internal static string GetText(AutomationElement control, TextPatternRange targetRange, int maxLength)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.GetText(maxLength);
        }

        /// <summary>
        ///     Retrieves an array of disjoint text ranges from a text container where each text range begins with the first
        ///     partially visible line through to the end of the last partially visible line
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     The collection of visible text ranges within the container or an empty array
        /// </returns>
        internal static TextPatternRange[] GetVisibleRanges(AutomationElement control)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.GetVisibleRanges();
        }

        /// <summary>
        ///     Retrieves a text range enclosing a child element such as an image, hyperlink, Microsoft Excel spreadsheet, or other embedded object
        /// </summary>
        /// <param name = "control">The enclosed object</param>
        /// <returns>
        ///     A range that spans the child element
        /// </returns>
        internal static TextPatternRange GetRangeFromChild(AutomationElement control)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.RangeFromChild(control);
        }

        /// <summary>
        ///     Returns the degenerate (empty) text range nearest to the specified screen coordinates
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "screenLocation">The location in screen coordinates</param>
        /// <returns>
        ///     A degenerate range nearest the specified location
        /// </returns>
        internal static TextPatternRange GetRangeFromPoint(AutomationElement control, Point screenLocation)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.RangeFromPoint(screenLocation);
        }

        #endregion ITextProvider Implementation

        #region ITextRangeProvider Implementation

        /// <summary>
        ///     Adds to the collection of highlighted text in a text container that supports multiple, disjoint selections.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range to add to the selections.</param>
        internal static void AddToSelection(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            targetRange.AddToSelection();
        }

        /// <summary>
        ///     Retrieves a new TextPatternRange identical to the original TextPatternRange and inheriting all properties of the original.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The range to clone.</param>
        /// <returns>The new text range.</returns>
        internal static TextPatternRange Clone(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.Clone();
        }

        /// <summary>
        ///     Returns a Boolean value indicating whether the span (the Start endpoint to the End endpoint) of a text range is the same as another text range
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "sourceRange">The source range to compare</param>
        /// <param name = "targetRange">The target range to compare</param>
        /// <returns>true if the span of both text ranges is identical; otherwise false</returns>
        internal static bool Compare(AutomationElement control, TextPatternRange sourceRange, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return sourceRange.Compare(targetRange);
        }

        /// <summary>
        ///     Returns an Int32 indicating whether two text ranges have identical endpoints
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "sourceRange">The source range for comparison.</param>
        /// <param name = "sourceEndpoint">The Start or End endpoint of the source range.</param>
        /// <param name = "targetRange">The target range for comparison.</param>
        /// <param name = "targetEndpoint">The Start or End endpoint of the target.</param>
        /// <returns>
        ///     Returns a negative value if the source's endpoint occurs earlier in the text than the target endpoint.
        ///     Returns zero if the source's endpoint is at the same location as the target endpoint.
        ///     Returns a positive value if the source's endpoint occurs later in the text than the target endpoint.
        /// </returns>
        internal static int CompareEndpoints(AutomationElement control, TextPatternRange sourceRange, TextPatternRangeEndpoint sourceEndpoint, TextPatternRange targetRange, TextPatternRangeEndpoint targetEndpoint)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return sourceRange.CompareEndpoints(sourceEndpoint, targetRange, targetEndpoint);
        }

        /// <summary>
        ///     Expands the text range to the specified TextUnit.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "unit">The textual unit.</param>
        internal static void ExpandToEnclosingUnit(AutomationElement control, TextUnit unit)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            TextPatternRange[] selection = pat.GetSelection();
            selection[0].ExpandToEnclosingUnit(unit);
        }

        /// <summary>
        ///     Returns a text range subset that has the specified attribute value.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "attribute">The attribute to search for.</param>
        /// <param name = "value">The attribute value to search for. This value must match the type specified for the attribute.</param>
        /// <param name = "backward">true if the last occurring text range should be returned instead of the first; otherwise false.</param>
        /// <param name = "targetRange">The target range.</param>
        /// <returns>
        ///     A text range having a matching attribute and attribute value; otherwise null
        /// </returns>
        internal static TextPatternRange FindAttribute(AutomationElement control, TextPatternRange targetRange, AutomationTextAttribute attribute, object value, bool backward)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.FindAttribute(attribute, value, backward);
        }

        /// <summary>
        ///     Finds the desired text within the whole document text.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "find">The string to find.</param>
        /// <param name = "searchBackward">if set to <c>true</c> search backward from the end of the document.</param>
        /// <param name = "ignoreCase">if set to <c>true</c> ignore case.</param>
        /// <returns>A text range matching the specified text; otherwise null </returns>
        internal static TextPatternRange FindText(AutomationElement control, string find, bool searchBackward, bool ignoreCase)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.DocumentRange.FindText(find, searchBackward, ignoreCase);
        }

        /// <summary>
        ///     Retrieves a collection of bounding rectangles for each fully or partially visible line of text in a text range
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range.</param>
        /// <returns>
        ///     An array of bounding rectangles for each full or partial line of text in a text range.
        ///     An empty array for a degenerate text range.
        ///     An empty array for a text range that has screen coordinates placing it completely off-screen, scrolled out of view, or obscured by an overlapping window
        /// </returns>
        internal static Rect[] GetBoundingRectangles(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.GetBoundingRectangles();
        }

        /// <summary>
        ///     Retrieves a collection of all embedded objects that fall within the text range.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range to search for the objects.</param>
        /// <returns>
        ///     A collection of all child objects that fall within the range. Children that overlap with the range but are not entirely enclosed by
        ///     it will also be included in the collection. Returns an empty collection if there are no child objects
        /// </returns>
        internal static List<AutomationElement> GetChildren(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            List<AutomationElement> childElements = new List<AutomationElement>(targetRange.GetChildren());

            return childElements;
        }

        /// <summary>
        ///     Returns the innermost AutomationElement that encloses the text range
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range.</param>
        /// <returns>The innermost element enclosing the target range</returns>
        internal static AutomationElement GetEnclosingElement(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.GetEnclosingElement();
        }

        /// <summary>
        ///     Returns the plain text of the text range.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "maxLength">The maximum length of the string to return. Use -1 if no limit is required</param>
        /// <returns>
        ///     The plain text of the text range, possibly truncated at the specified maxLength
        /// </returns>
        internal static string GetText(AutomationElement control, int maxLength)
        {
            TextPattern pat = (TextPattern)CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return pat.DocumentRange.GetText(maxLength);
        }

        /// <summary>
        ///     Moves the text range the specified number of text units
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range.</param>
        /// <param name = "unit">The text unit boundary.</param>
        /// <param name = "count">The number of text units to move. A positive value moves the text range forward, a negative value moves the text range backward,
        ///     and 0 has no effect.</param>
        /// <returns>
        ///     The number of units actually moved. This can be less than the number requested if either of the new text range endpoints is greater than or less than
        ///     the DocumentRange endpoints
        /// </returns>
        internal static int Move(AutomationElement control, TextPatternRange targetRange, TextUnit unit, int count)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.Move(unit, count);
        }

        /// <summary>
        ///     Moves the source endpoint of a text range to the specified endpoint of the target text range.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "sourceRange">The range to move its endpoint</param>
        /// <param name = "sourceEndpoint">The endpoint to move.</param>
        /// <param name = "targetRange">Another range from the same text provider.</param>
        /// <param name = "targetEndpoint">The target endpoint.</param>
        internal static void MoveEndpointByRange(AutomationElement control, TextPatternRange sourceRange, TextPatternRangeEndpoint sourceEndpoint, TextPatternRange targetRange, TextPatternRangeEndpoint targetEndpoint)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            sourceRange.MoveEndpointByRange(sourceEndpoint, targetRange, targetEndpoint);
        }

        /// <summary>
        ///     Moves one endpoint of the text range the specified number of TextUnits within the document range.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "endpoint">The endpoint to move.</param>
        /// <param name = "unit">The textual unit for moving.</param>
        /// <param name = "count">The number of units to move. A positive count moves the endpoint forward. A negative count moves backward. A count of 0 has no effect.</param>
        /// <param name = "targetRange">The target range.</param>
        /// <returns>
        ///     The number of units actually moved, which can be less than the number requested if moving the endpoint runs into the beginning or end of the document
        /// </returns>
        internal static int MoveEndpointByUnit(AutomationElement control, TextPatternRangeEndpoint endpoint, TextUnit unit, int count, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            return targetRange.MoveEndpointByUnit(endpoint, unit, count);
        }

        /// <summary>
        ///     Removes a highlighted section of text, corresponding to the calling text range Start and End endpoints, from an existing collection of highlighted text in a text container that supports multiple, disjoint selections.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The target range.</param>
        internal static void RemoveFromSelection(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            targetRange.RemoveFromSelection();
        }

        /// <summary>
        ///     Causes the text control to scroll vertically until the text range is visible in the viewport.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "alignToTop">true if the text control should be scrolled so the text range is flush with the top of the viewport; false if it should be flush with the bottom of the viewport.</param>
        /// <param name = "targetRange">The target range.</param>
        internal static void ScrollIntoView(AutomationElement control, bool alignToTop, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);
            targetRange.ScrollIntoView(alignToTop);
        }

        /// <summary>
        ///     Searches for, then highlights text in the text control corresponding to the text range Start and End endpoints.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "find">The string to find.</param>
        /// <param name = "ignoreCase">if set to <c>true</c> ignores case.</param>
        internal static void Select(AutomationElement control, string find, bool ignoreCase)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);

            TextPatternRange range = FindText(control, find, false, ignoreCase);
            if (range == null) return;
            range.Select();
            range.ScrollIntoView(true);
        }

        /// <summary>
        ///     Highlights text in the text control corresponding to the text range Start and End endpoints
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "targetRange">The text range to select.</param>
        internal static void Select(AutomationElement control, TextPatternRange targetRange)
        {
            CommonUIAPatternHelpers.CheckPatternSupport(TextPattern.Pattern, control);

            targetRange.Select();
            targetRange.ScrollIntoView(true);
        }

        #endregion ITextRangeProvider Implementation
    }
}