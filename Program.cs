using System;

namespace EventHandlers
{
    public delegate void MyDelegate1(object sender, MyEventArgs args);
    public delegate void MyDelegate2(object sender, MyEventArgs args);

    class MyClass1
    {

        public void MyHandler1(object sender, MyEventArgs args)
        {
            Console.WriteLine($"Message from Handler1 fired from {args.EventMessage}");
            
        }
        public void MyHandler2(object sender, MyEventArgs args)
        {
            Console.WriteLine($"Message from Handler2 fired from {args.EventMessage}");
            
        }
        public MyClass1(MyClass2 class2)
        {
            MyDelegate1 delegate1 = new MyDelegate1(MyHandler1);
            MyDelegate2 delegate2 = new MyDelegate2(MyHandler2);
            class2.MyEvent1 += delegate1;
            class2.MyEvent2 += delegate2;


        }


    }

    class MyClass2
    {
        public event MyDelegate1 MyEvent1;
        public event MyDelegate2 MyEvent2;

        public void FireEvent1(MyEventArgs args)
        {
            if (MyEvent1 != null)
                MyEvent1(this, args);
        }
        public void FireEvent2(MyEventArgs args)
        {
            if (MyEvent2 != null)
                MyEvent2(this, args);
        }
            
    }

    public class MyEventArgs : EventArgs
    { 
        public string EventMessage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass2 class2 = new MyClass2();
            MyClass1 class1 = new MyClass1(class2);
            MyEventArgs args1 = new MyEventArgs() { EventMessage = "Event1" };
            MyEventArgs args2 = new MyEventArgs() { EventMessage = "Event2" };
            class2.FireEvent1(args1);
            class2.FireEvent2(args2);
        }
    }
}
