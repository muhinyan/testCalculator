using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Windows.Automation;
using OpenQA.Selenium.Remote;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace Tests
{
    [TestFixture]
    public class TestFixture1
    {
        [Test]
        public void TestTrue()
        {
           
            var calc = new Winium.Cruciatus.Application("C:/windows/system32/calc.exe");
            calc.Start();
            var winFinder = By.Name("Калькулятор").AndType(ControlType.Window);
            var window = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);//Инициализатор типа "Winium.Cruciatus.CruciatusFactory" выдал исключение.
         
            
            Random rnd = new Random();
            int value = rnd.Next(1, 100); 
            string strVal=Convert.ToString(value);
            var textField = window.FindElementByUid("150");
            textField.Click();
            textField.SetText(strVal);//шаг2
            /*
            String strVal="", strVal1 = "", strVal2="";
            Random rnd = new Random();
            int value = rnd.Next(1, 100); //ввод кнопками
            if (value >= 10)
            {
                strVal = Convert.ToString(value);
                strVal1 = strVal.Substring(0,1);
                strVal1 = "13" + strVal1;
                window.FindElementByUid(strVal1);
                strVal2 = strVal.Substring(1,1);
                strVal2 = "13" + strVal2;
                window.FindElementByUid(strVal2);
            
            }
            else {
                strVal = Convert.ToString(value);
                strVal = "13" + strVal;
                window.FindElementByUid(strVal);
               
            }
             */
            window.FindElementByUid("110").Click();//кнопка_корень
            var textField2 = window.FindElementByUid("404");
             string sravn = "sqrt(" + value + ")";

            string sravnField = textField2.Text();
            if (sravn == sravnField)
                Console.WriteLine("Операция отображена верно");//шаг3


            strVal = textField.Text();
            double valField = Convert.ToDouble(strVal);
           
            double valSqrt = Math.Sqrt(value);
            if (valField == valSqrt)
                Console.WriteLine("Корни равны");//шаг4
            window.FindElementByUid("92").Click();
            window.FindElementByUid("121").Click();
            strVal = textField.Text();
            if (value == Convert.ToInt32(strVal))
            { Console.WriteLine("Число из которого вычисляли корень"); } //шаг5
            calc.Close();

            /*
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:/windows/system32/calc.exe");
            var driver = new RemoteWebDriver(new Uri("https://localhost:9999"), dc);
            var window = driver.FindElementByClassName("CalcFrame");
            
            Random rnd = new Random();
            int value = rnd.Next(1, 100); //добавить ввод кнопками
            string valStr=Convert.ToString(value);

            var textField =window.FindElement(OpenQA.Selenium.By.Id("150"));
            textField.Click();
            textField.SendKeys(strVal);//шаг2
            window.FindElement(OpenQA.Selenium.By.Id("110")).Click(); //кнопка_корень
            var textField2 = window.FindElement(OpenQA.Selenium.By.Id("404"));
            string sravn = "sqrt(" + value + ")";

            string sravnField = textField2.Text();//()
            if (sravn == sravnField)
                Console.WriteLine("Операция отображена верно");//шаг3


            valStr = textField.Text;
            double valField = Convert.ToDouble(strVal);
           
            double valSqrt = Math.Sqrt(value);
            if (valField == valSqrt)
                Console.WriteLine("Корни равны");//шаг4
            window.FindElement(OpenQA.Selenium.By.Id("92")).Click();//кнопка_умножения
            window.FindElement(OpenQA.Selenium.By.Id("121")).Click();//кнопка_равно
            strVal = textField.Text;
            if (value == Convert.ToInt32(strVal))
            { Console.WriteLine("Число из которого вычисляли корень"); }
            driver.Quit();
             
             */




        }

    }
}
