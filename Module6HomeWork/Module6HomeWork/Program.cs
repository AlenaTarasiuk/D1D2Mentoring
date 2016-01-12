using System;

namespace Module6HomeWork
{
    class Program
    {
        private const string Path = @"D:\Calculator\Calculator\Lib";

        static void Main(string[] args)
        {
            var fileSystemVisitor = SetUpFileSystemVisitor();

            var results = fileSystemVisitor.Enumerate(Path);

            foreach (var result in results)
            {
                System.Console.WriteLine(result);
            }
        }

        private static FileSystemVisitor SetUpFileSystemVisitor()
        {
            var fileSystemVisitor = new FileSystemVisitor(s => s.EndsWith(".config"));
            fileSystemVisitor.Start += (sender, eventArgs) => System.Console.WriteLine("Start");
            fileSystemVisitor.Finish += (sender, eventArgs) => System.Console.WriteLine("Finish");

            fileSystemVisitor.FileFinded += FileSystemVisitorOnFileFinded;
            fileSystemVisitor.FilteredFileFinded += FileSystemVisitorOnFileFinded;
                    
            fileSystemVisitor.DirectoryFinded += (sender, args) => System.Console.WriteLine("Directory : { args.Path } ");
            fileSystemVisitor.FileFinded += (sender, args) => System.Console.WriteLine("File : { args.Path } ");

            return fileSystemVisitor;
        }

        private static void FileSystemVisitorOnFileFinded(object sender, ItemFindedEventArgs args)
        {
            System.Console.WriteLine("File : { args.Path } ");
                        if (args.Path.Contains("Installer"))
                            args.ShouldStopSearch = true;
        }
    }
}
