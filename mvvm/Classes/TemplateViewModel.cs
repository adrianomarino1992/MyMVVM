using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVM.Classes;
using MyMVVM.Attributes;
using MyMVVM.Delegates;
using MyRefs.Extensions;
using System.Reflection;

namespace mvvm.Classes
{
    public class TemplateViewModel : ViewModelBase
    {

        
        public string Nome { get; set; }

        [Label("Selecione")]
        [Combo(typeof(GetEmailsDelegate))]
        public string Email { get; set; }


        
            
        public string Telefone { get; set; }


        [Label("Carro:")]
        [Combo(typeof(GetCarrosDelegate))]
        public Car Carro { get; set; }

        public double Salario { get; set; }

        
        public List<string> Nomes { get; set; }
        public List<long> Idades { get; set; }
        public List<float> Salarios { get; set; }
        public List<Car> Carros { get; set; }
    }



    public class Car : ViewModelBase
    {
        public string Brand { get; init; }
        public string Model { get; init; }

        public string Age { get; init; }
        public string Owner { get; init; }


        public string Plate { get; init; }
        public string Color { get; init; }

        public Engine Engine { get; init; }

        public override string ToString()
        {
            return $"{Brand} - {Model}";
        }
    }


    public class Engine : ViewModelBase
    {
        public string Brand { get; init; }
        public string Model { get; init; }

        public string Age { get; init; }

    }







    public class GetEmailsDelegate : IGetValuesDelegate
    {
        public string? GetLabelPropertyName()
        {
            return null;
        }
        public string? GetValuePropertyName()
        {
            return null;
        }

        public object? GetValue(object obj)
        {
            return obj.GetPropertyValue<string>(nameof(TemplateViewModel.Email));
        }

        object[] IGetValuesDelegate.GetItens()
        {
            return new object[]
            {    
                "adriano@gmail.com",
                "camis@gmail.com",
                "lixin@gmail.com"
            };
        }
    }


    public class GetCarrosDelegate : IGetValuesDelegate
    {
        public string? GetLabelPropertyName()
        {
            return null;// nameof(Car.Brand);
        }
        public string? GetValuePropertyName()
        {
            return null; // nameof(Car.Model);
        }

        public object? GetValue(object obj)
        {
            return obj.GetPropertyValue<Car>(nameof(TemplateViewModel.Carro));
        }

        object[] IGetValuesDelegate.GetItens()
        {
            return new object[]
            {
                new Car
                {
                Brand = "VW", 
                Model = "Fusca"
                },
                 new Car
                {
                Brand = "Ford",
                Model = "New Fiest"
                },
                 new Car
                {
                Brand = "Ford",
                Model = "New Focus"
                }
            };
        }
    }



}
