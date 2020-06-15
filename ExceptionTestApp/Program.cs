using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 5, value = 0; // 에러가 날 이유가없음

            try // 에러가 날수 있는 부분
            {
                value = x / y;
                Console.WriteLine($"{x}/{y} = {value}");
                // throw new Exception("사용자 에러"); 
            }
            catch (DivideByZeroException ex) // 하위
            {
                Console.WriteLine("2.y의 값을 0보다 크게 입력하세요.");
            }
            catch (Exception ex) // 부모 (항상 뒤에 있어야함)
            {
                Console.WriteLine("3." + ex.Message);
            }
            finally // 에러의 유무없이 무조건 실행
            {
                Console.WriteLine("4.프로그램이 종료했습니다.");
            }
        }
    }
}
