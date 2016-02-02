using System;

namespace Module6HomeWork
{
    public class ItemFindedEventArgs : EventArgs
    {
        public string Path { get; set; }
        public ItemType Type { get; set; }

        public ItemFindedEventArgs(string path, ItemType type)
        {
            Path = path;
            Type = type;
        }

        public bool ShouldStopSearch { get; set; }
        public bool ShouldExcludeItem { get; set; }
    }
}
