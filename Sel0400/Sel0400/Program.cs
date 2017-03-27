using System;
using Sel0400.Autotests.Sel0401;
using Sel0400.Autotests.Sel0402;
using Sel0400.Autotests.Sel0407;
using Sel0400.Autotests.Sel0408;
using Sel0400.Autotests.Sel0409;
using Sel0400.Autotests.Sel0410;
using Sel0400.Autotests.Sel0411;
using Sel0400.Autotests.Sel0412;
using Sel0400.Autotests.Sel0413;
using Sel0400.Autotests.Sel0414;
using Sel0400.Autotests.Sel0417;

namespace Sel0400
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Please select Autotests: \n 1 - [x] Задание 1. Подготовьте инфраструктуру \n" +
                        " 2 - [x] Задание 3. Сделайте сценарий логина \n" +
                        " 7 - [x] Задание 7. Сделайте сценарий, проходящий по всем разделам админки \n" +
                        " 8 - [x] Задание 8. Сделайте сценарий, проверяющий наличие стикеров у товаров \n" +
                        " 9 - [x] Задание 9. Проверить сортировку стран и геозон в админке \n" +
                        "10 - [x] Задание 10. Проверить, что открывается правильная страница товара \n" +
                        "11 - [x] Задание 11. Сделайте сценарий регистрации пользователя \n" +
                        "12 - [x] Задание 12. Сделайте сценарий добавления товара \n" +
                        "13 - [x] Задание 13. Сделайте сценарий работы с корзиной \n" +
                        "14 - [x] Задание 14. Проверьте, что ссылки открываются в новом окне \n" +
                        "17 - [x] Задание 17. Проверьте отсутствие сообщений в логе браузера");
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
        case "10":
          Sel0410.Test01_VerifyProductAfterAddToCart();
          break;
        case "11":
          Sel0411.Test01_VerifiregistartionAndReloginNewUser();
          break;
        case "12":
          Sel0412.Test01_Admin_VerifyNewProduct();
          break;
        case "13":
          Sel0413.Test01_VerifyAddProductToCheckout();
          break;
        case "14":
          Sel0414.Test01_VerifyOpenLinkInNewtab();
          break;
        case "17":
          Sel0417.Test01_VerifyOpenLinkInNewtab();
          break;
        default:
          Console.WriteLine("Incorrect inputnumber");
          break;
      }
      
    }
  }
}
