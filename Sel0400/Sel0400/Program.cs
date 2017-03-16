using System;
using Sel0400.Autotests.Sel0401;
using Sel0400.Autotests.Sel0402;
using Sel0400.Autotests.Sel0407;
using Sel0400.Autotests.Sel0408;
using Sel0400.Autotests.Sel0409;

namespace Sel0400
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Please select Autotests: \n1 - [x] Задание 1. Подготовьте инфраструктуру \n" +
                        "2 - [x] Задание 3. Сделайте сценарий логина \n" +
                        "7 - [x] Задание 7. Сделайте сценарий, проходящий по всем разделам админки \n" +
                        "8 - [x] Задание 8. Сделайте сценарий, проверяющий наличие стикеров у товаров \n" +
                        "9 - [x] Задание 9. Проверить сортировку стран и геозон в админке");
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
        case "8":
          Sel0408.Test01_HomePage_VerifyLabelOnProduc();
          break;
        case "9":
          Sel0409.Test01_VerifyDefaultSortCountry();
          break;
        default:
          Console.WriteLine("Incorrect inputnumber");
          break;
      }
      
    }
  }
}
