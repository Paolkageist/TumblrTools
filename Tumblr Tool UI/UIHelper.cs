﻿/* 01010011 01101000 01101001 01101110 01101111  01000001 01101101 01100001 01101011 01110101 01110011 01100001
 *
 *  Project: Tumblr Tools - Image parser and downloader from Tumblr blog system
 *
 *  Author: Shino Amakusa
 *
 *  Created: 2013
 *
 *  Last Updated: December, 2014
 *
 * 01010011 01101000 01101001 01101110 01101111  01000001 01101101 01100001 01101011 01110101 01110011 01100001 */

namespace Tumblr_Tool
{
    public static class UIHelper
    {
        public static void SelectItem(this AdvancedComboBox ddl, string value)
        {
            ddl.SelectedIndex = ddl.FindString(value) != -1 ? ddl.FindString(value) : 0;
        }
    }
}