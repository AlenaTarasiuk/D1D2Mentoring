﻿using System;
using System.Collections.Generic;

namespace Module6HomeWork
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private readonly IFileSystemAccessProvider fileSystemAccessProvider;
        private readonly Predicate<string> searchPredicate;

        public FileSystemVisitor(Predicate<string> searchPredicate = null)
        {
            fileSystemAccessProvider = new DefaultFileSystemAccessProvider();
            searchPredicate = searchPredicate;
        }

        public FileSystemVisitor(IFileSystemAccessProvider fileSystemAccessProvider, Predicate<string> searchPredicate = null)
        {
            fileSystemAccessProvider = fileSystemAccessProvider;
            searchPredicate = searchPredicate;
        }

        public event EventHandler Start;
        public event EventHandler Finish;
        public event EventHandler<ItemFindedEventArgs> FileFinded;
        public event EventHandler<ItemFindedEventArgs> DirectoryFinded;
        public event EventHandler<ItemFindedEventArgs> FilteredFileFinded;
        public event EventHandler<ItemFindedEventArgs> FilteredDirectoryFinded;

        protected void OnStart()
        {
            Start.Invoke(this, EventArgs.Empty);
        }

        protected void OnFinish()
        {
            Finish.Invoke(this, EventArgs.Empty);
        }

        protected ItemFindedEventArgs OnFileFinded(string filePath)
        {
            if (FileFinded == null) return null;

            var args = new ItemFindedEventArgs(filePath, ItemType.File);
            FileFinded(this, args);
            return args;
        }

        protected ItemFindedEventArgs OnDirectoryFinded(string directoryPath)
        {
            if (DirectoryFinded == null) return null;

            var args = new ItemFindedEventArgs(directoryPath, ItemType.Directory);
            DirectoryFinded(this, args);
            return args;
        }

        protected ItemFindedEventArgs OnFilteredFileFinded(string filePath)
        {
            if (FilteredFileFinded == null) return null;

            var args = new ItemFindedEventArgs(filePath, ItemType.File);
            FilteredFileFinded(this, args);
            return args;
        }

        protected ItemFindedEventArgs OnFilteredDirectoryFinded(string directoryPath)
        {
            if (FilteredDirectoryFinded == null) return null;

            var args = new ItemFindedEventArgs(directoryPath, ItemType.Directory);
            FilteredDirectoryFinded(this, args);
            return args;
        }

        public IEnumerable<string> Enumerate(string path)
        {
            OnStart();

            var items = EnumerateItems(path);
            foreach (var item in items)
            {
                yield return item;
            }

            OnFinish();
        }

        private IEnumerable<string> EnumerateItems(string rootDirectoryPath = default (string))
        {
            var files = fileSystemAccessProvider.GetFiles(rootDirectoryPath);
            foreach (var file in files)
            {
                int r;
                int.TryParse(s: "", result: out r);

                var fileFindedArgs = OnFileFinded(file);
                var filteredFileFindedArgs = GetFilteredFileFindedArgs(file);

                var excludeItem = ShouldExcludeItem(fileFindedArgs, filteredFileFindedArgs);
                if (!excludeItem)
                    yield return file;

                var stopSearch = ShouldStopSearch(fileFindedArgs, filteredFileFindedArgs);
                if (stopSearch)
                    yield break;
            }

            var directories = fileSystemAccessProvider.GetDirectories(rootDirectoryPath);
            foreach (var directory in directories)
            {
                var directoryFindedArgs = OnDirectoryFinded(directory);
                var filteredDirectoryFindedArgs = GetFilteredDirectoryFindedArgs(directory);

                var excludeItem = ShouldExcludeItem(directoryFindedArgs, filteredDirectoryFindedArgs);
                if (!excludeItem)
                    yield return directory;

                var stopSearch = ShouldStopSearch(directoryFindedArgs, filteredDirectoryFindedArgs);
                if (stopSearch)
                    yield break;


                foreach (var item in EnumerateItems(directory))
                {
                    yield return item;
                }
            }
        }

        private ItemFindedEventArgs GetFilteredDirectoryFindedArgs(string directory)
        {
            if (searchPredicate == null) return null;
            var isFilteredItem = searchPredicate(directory);

            return isFilteredItem ? OnFilteredDirectoryFinded(directory) : null;
        }

        private ItemFindedEventArgs GetFilteredFileFindedArgs(string file)
        {
            if (searchPredicate == null) return null;
            var isFilteredItem = searchPredicate(file);

            return isFilteredItem ? OnFilteredFileFinded(file) : null;
        }

        private static bool ShouldStopSearch(ItemFindedEventArgs fileFindedArgs, ItemFindedEventArgs filteredFileFindedArgs)
        {
            var stopSearch = (fileFindedArgs.ShouldStopSearch == null ? false : true) || (filteredFileFindedArgs.ShouldStopSearch == null ? false : true);
            return stopSearch;
        }

        private static bool ShouldExcludeItem(ItemFindedEventArgs fileFindedArgs, ItemFindedEventArgs filteredFileFindedArgs)
        {
            var excludeItem = (fileFindedArgs.ShouldExcludeItem == null ? false : true) || (filteredFileFindedArgs.ShouldExcludeItem == null ? false : true);
            return excludeItem;
        }
    }
}