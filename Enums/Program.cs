public class Program {
    public static void Main(string[] arg) {
        // Console.WriteLine("jay mataji");
        // Console.WriteLine(Days.mon); // mon
        // Console.WriteLine((int)Days.mon); // 100
        // Console.WriteLine(typeof(Days)); 

        // foreach(Days d in Enum.GetValues(typeof(Days))) {
        //     Console.WriteLine(d);
        // }

        // for(int i = 0; i <= 100; i++) {
        //     if((i % 3 == 0) && (i % 5 == 0)) 
        //     {
        //         Console.WriteLine(i + " - " + "FizzBuzz"); 
        //     } else if(i % 3 == 0)
        //     {
        //         Console.WriteLine(i + " - " + "Fizz");
        //     } else if(i % 5 == 0)
        //     {
        //         Console.WriteLine(i + " - " + "Buzz");
        //     } else {
        //         Console.WriteLine(i);
        //     }
        // }

        int hero = 10;
        int monster = 10;

        int monD = 0;
        int heroD = 0;

        do {
            Random rnd = new Random();
            monD = rnd.Next(1, 11);
            monster = monster - monD;
            Console.WriteLine("Monster was damaged and lost "+ monD +" health and now has "+monster+" health.");
        } while(hero <= 0 || monster <= 0)
    }
}

// enum Days {
//     mon = 100,
//     tue = 200,
//     wed = 300,
//     thu = 400,
//     fri = 500,
//     sat = 600,
//     sun = 700
// }