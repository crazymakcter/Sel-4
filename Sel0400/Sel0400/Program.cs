using System;
using Sel0400.Autotests.Sel0401;
using Sel0400.Autotests.Sel0402;
using Sel0400.Autotests.Sel0407;

namespace Sel0400
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Please select Autotests: \n1 - [x] Задание 1. Подготовьте инфраструктуру \n" +
                        "2 - [x] Задание 3. Сделайте сценарий логина \n7 - [x] Задание 7. Сделайте сценарий, проходящий по всем разделам админки");
      string selectNimber = Console.ReadLine();
      switch (selectNimber)
      {
        case "1":
          Sel0401.Test01_OpenGoogleAndSearch();
          break;
        case "2":
          Sel0402.Test01_Admin_LoginAndVerify();
          break;
        case "7":
          Sel0407.Test01_Admin_OpenAllMenuAndsubmenu();
          break;
        default:
          Console.WriteLine("Incorrect inputnumber");
          break;
      }
      
    }
  }
}
