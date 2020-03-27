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
           // int strVal, strVal1;

            Random rnd = new Random();
            int value = rnd.Next(1, 100); //ввод кнопками
            if (value >= 10)
            {
                window.FindElement(By.XPath("/[@ControlType=\"ControlType.Button\"]and [@Name=\""+value/10+"\"]")).Click();
                window.FindElement(By.XPath("/[@ControlType=\"ControlType.Button\"]and [@Name=\"" + value % 10 + "\"]")).Click();
            }
            else 
                window.FindElement(By.XPath("/[@ControlType=\"ControlType.Button\"]and [@Name=\"" + value +"\"]")).Click();

              
            
            window.FindElement(By.XPath("/[@ControlType=\"ControlType.Button\"]and [@Name=\"Квадратный корень\"]")).Click();//кнопка_корень
            var textField2 = window.FindElement(By.XPath("/[@ControlType=\"ControlType.Text\"]and [@Name=\"sqrt(" + value + ")\"]"));
            string sravn = "sqrt(" + value + ")";

            string sravnField = textField2.Text();//берем текст из верхнего поля
            if (sravn == sravnField)
                Console.WriteLine("Операция отображена верно");//шаг3

            string fieldVal;
            var textField = window.FindElement(By.XPath("/[@ControlType=\"ControlType.Text\"]and [@Name=\"" + Math.Sqrt(value) + "\"]"));
            //можно не писать проверку, если поле не найдено, значит посчиталось не верно
            fieldVal = textField.Text();
            double valField = Convert.ToDouble(fieldVal);
            double valSqrt = Math.Sqrt(value);
            if (valField == valSqrt)
                Console.WriteLine("Корни равны");//шаг4

            window.FindElement(By.XPath("/[@ControlType=\"ControlType.Button\"]and [@Name=\"Умножение\"]")).Click();
            window.FindElement(By.XPath("/[@ControlType=\"ControlType.Button\"]and [@Name=\"Равно\"]")).Click();
            textField = window.FindElement(By.XPath("/[@ControlType=\"ControlType.Text\"]and [@Name=\"" + value + "\"]"));
            //можно не писать проверку, если поле не найдено, значит посчиталось не верно
            fieldVal = textField.Text();
            if (value == Convert.ToInt32(fieldVal))
            { Console.WriteLine("Число из которого вычисляли корень"); } //шаг5
            calc.Close();

           


        }

    }
}
