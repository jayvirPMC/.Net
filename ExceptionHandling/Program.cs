public class Program {
    public static void Main(string[] args) {
        int[] num = {12, 21, 32, 33, 23};
        int[] den = {12, 21, 32, 0, 23, 32};
        int[] ans = new int[num.Length];


            for(int i = 0; i < num.Length; i++) {
                try{
                    ans[i] = num[i] / den[i + 1];
                } catch(DivideByZeroException e) {
                    Console.WriteLine("message: " + e.Message);
                } catch(IndexOutOfRangeException ie) {
                    Console.WriteLine("message: " + ie.Message);
                }
            }

        foreach(int i in ans) {
            Console.WriteLine(i);
        }


    }
}