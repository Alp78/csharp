// Delegate: an object that knows how to call a methos (or group of methods)
// a reference (pointer) to a function

// in case you need a new method to a class without recompiling the entire code -> extensibility
// design exstensible and flexible apps (e.g. frameworks)

// this can be done also with interfaces
// use delegate when:
// - an eventing design pattern is used
// - caller doesn't need to access other properties or methods on the object implementing the method

using System;

namespace Advanced
{
    public class Photo
    {
        public int Brightness;
        public int Contrast;
        public int Size;

        public static Photo Load(string path)
        {
            var photo = new Photo();
            return photo;
        }

        public void Save()
        {

        }

    }



    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize");
        }
    }

    public class PhotoProcessor
    {
        // delcare a delegate
        public delegate void PhotoFilterHandler(Photo photo);

        // method taking the delegate as argument: can be any filter (extension)
        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }

        // classic way: has to declare each filter separately
        public void Process(string path)
        {
            var photo = Photo.Load(path);
            var filters = new PhotoFilters();
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);
            filters.Resize(photo);

            photo.Save();
        
        }
    }


    class Program
    {
        // creating a new filter (only signature must match the delegate)
        static void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Remove Red Eye");
        }

        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            // setting a filter with delegate
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;

            // adding another filter
            filterHandler += filters.ApplyContrast;

            filterHandler += RemoveRedEye;


            processor.Process("photo.jpg", filterHandler);

            Console.ReadKey();

        }
    }
}
