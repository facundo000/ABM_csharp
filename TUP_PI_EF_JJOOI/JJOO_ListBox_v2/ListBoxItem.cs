﻿namespace JJOO_ListBox
{
    internal class ListBoxItem
    {
        public string Text { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}