using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritance
{
    public interface IDraggable
    {
        void Drag();
    }

    public interface IDroppable
    {
        void Drop();
    }

    public class Size
    {
        public int size { get; set; }
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class UiControl
    {
        public string Id { get; set; }
        public Size Size { get; set; }
        public Position TopLeft { get; set; }

        public virtual void Draw()
        {

        }

        public void Focus()
        {
            Console.WriteLine("Received focus");
        }
    }

    // TextBox INHERITS from UiControl class and IMPLEMENTS IDraggable and IDroppable interfaces
    public class TextBox : UiControl, IDraggable, IDroppable
    {
        public void Drag()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }
    }

   


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
