using System;
using System.IO;

namespace obj
{
    class Program
    {
        static void Main(string[] args)
        {
          ship caravel = new ship("sun",1000,"sailing");
          ship sloop = new ship("rain",1100,"mast");
          
          caravel.repldisple(1300);
          caravel.repltype("steam");
          sloop.replname("Arizona");
          
          caravel.save();
          sloop.view();
          ship res = caravel+sloop;
          Console.WriteLine(res.ValueDisple);
          if (caravel>sloop)
          {
              Console.WriteLine("true");
          }
          else 
          {
              Console.WriteLine("False");
          }
        }
    }
    class ship
    {
        private string name,type;
        uint disple;
        public ship()
        {
            name = "No name";
            disple = 0;
            type = "No type";
        }
        public ship (string name,uint disple,string type)
        {
            this.name = name;
            this.disple = disple;
            this.type = type;
        }
       
        public void replname(string name)
        {
            this.name = name;
        }
        public void repldisple(uint disple)
        {
            this.disple = disple;
        }
        public void repltype(string type)
        {
            this.type = type;
        }
        public string str = @"C:\Users\Zi\Desktop\прогр\лаба7\ткст файл.txt";
        public void save()
        {
            using (FileStream fs = new FileStream(str,FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"name: {name}");
                    sw.WriteLine($"disple: {disple}");
                    sw.WriteLine($"type: {type}");
                }
            }
        }
         public void view ()
        {
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"disple: {disple}");
            Console.WriteLine($"type: {type}");
        }
        
        public string ValueName
        {
            get {return name;}
            set {name = value;}
        }
        public uint ValueDisple
        {
            get {return disple;}
            set {disple = value;}
        }
        public string ValueType
        {
            get {return type;}
            set {type= value;}
        }
        public  static ship operator +(ship c,ship s)
        {
            return new ship (c.name,c.ValueDisple + s.ValueDisple,c.type);
        }
        public static bool operator >(ship c, ship s )
        {
            return c.ValueDisple>s.ValueDisple;
        }
        public static bool operator <(ship c,ship s)
        {
            return c.ValueDisple<s.ValueDisple;
        }
    }
}