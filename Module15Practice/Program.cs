using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15Practice
{
    public class Program
    {
        static void Main()
        {
            // Задача 1: Исследование типа MyClass
            Type myType = typeof(MyClass);
            Console.WriteLine($"Имя класса: {myType.Name}");
            ConstructorInfo[] constructors = myType.GetConstructors();
            Console.WriteLine("\nКонструкторы:");
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine($" - {constructor}");
            }
            Console.WriteLine("\nПоля и свойства:");
            FieldInfo[] fields = myType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] properties = myType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($" - {field.FieldType} {field.Name}");
            }

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($" - {property.PropertyType} {property.Name}");
            }
            Console.WriteLine("\nМетоды:");
            MethodInfo[] methods = myType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($" - {method.ReturnType} {method.Name}");
            }

            // Задача 2: Создание экземпляра MyClass с использованием рефлексии
            MyClass myInstance = (MyClass)Activator.CreateInstance(myType);

            // Задача 3: Манипулирование объектом MyClass
            PropertyInfo publicProperty = myType.GetProperty("PublicProperty");
            publicProperty.SetValue(myInstance, 42);

            Console.WriteLine($"\nPublicProperty после изменения: {myInstance.PublicProperty}");

            MethodInfo modifyStateMethod = myType.GetMethod("ModifyState");
            modifyStateMethod.Invoke(myInstance, null);

            // Задача 4: Вызов приватного метода
            MethodInfo privateMethod = myType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(myInstance, null);
        } 
    }
}
