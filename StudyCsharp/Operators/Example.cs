using System;
using System.Collections.Generic;

namespace StudyCsharp.Operators
{
    class ExampleOperators
    {
        // overload : cho phép định nghĩa lại hành vi của các toán tử cho các kiểu dữ liệu tự định nghĩa
        public struct Vector2D
        {
            public int X { get; set; }
            public int Y { get; set; }

            public static Vector2D operator +(Vector2D v1, Vector2D v2)
            {
                return new Vector2D { X = v1.X + v2.X, Y = v1.Y + v2.Y };
            }
        }

        // overloading equality operators Cho phép tùy chỉnh cách so sánh bằng và không bằng giữa các đối tượng.
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public static bool operator ==(Person p1, Person p2)
            {
                if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null))
                    return true;
                if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                    return false;
                return p1.Name == p2.Name && p1.Age == p2.Age;
            }

            public static bool operator !=(Person p1, Person p2)
            {
                return !(p1 == p2);
            }
        }

        // Conditional Operators: Toán tử điều kiện cho phép thực hiện kiểm tra điều kiện ngắn gọn.
        void Conditional()
        {
            int x = 10;
            string result = (x > 5) ? "x lớn hơn 5" : "x nhỏ hơn hoặc bằng 5";
            Console.WriteLine(result);
        }

        // Implicit Cast and Explicit Cast Operators: Cho phép định nghĩa cách chuyển đổi kiểu ngầm định và tường minh giữa các kiểu dữ liệu.
        public struct Celsius
        {
            public double Temperature { get; }

            public Celsius(double temperature)
            {
                Temperature = temperature;
            }

            // Chuyển đổi ngầm định từ double sang Celsius
            public static implicit operator Celsius(double temperature)
            {
                return new Celsius(temperature);
            }

            // Chuyển đổi tường minh từ Celsius sang Fahrenheit
            public static explicit operator Fahrenheit(Celsius celsius)
            {
                return new Fahrenheit(celsius.Temperature * 9 / 5 + 32);
            }
        }

        public struct Fahrenheit
        {
            public double Temperature { get; }

            public Fahrenheit(double temperature)
            {
                Temperature = temperature;
            }
        }

        // Short-circuiting Operators: Toán tử đoản mạch giúp tối ưu hóa việc đánh giá biểu thức logic.
        void ShortCircuiting()
        {
            bool CheckCondition1()
            {
                Console.WriteLine("Kiểm tra điều kiện 1");
                return false;
            }

            bool CheckCondition2()
            {
                Console.WriteLine("Kiểm tra điều kiện 2");
                return true;
            }

            if (CheckCondition1() && CheckCondition2())
            {
                Console.WriteLine("Cả hai điều kiện đều đúng");
            }
            else
            {
                Console.WriteLine("Ít nhất một điều kiện sai");
            }
        }

        // Ternary : Toán tử ba ngôi cho phép viết các câu lệnh điều kiện ngắn gọn.
        void Ternary()
        {
            int age = 20;
            string status = (age >= 18) ? "Người lớn" : "Trẻ em";
            Console.WriteLine(status);
        }

        // Null Coalescing Operators : Toán tử null coalescing giúp xử lý giá trị null một cách ngắn gọn.
        void NullCoalescing()
        {
            string name = null;
            string displayName = name ?? "Khách";
            Console.WriteLine(displayName);
        }

        // "Exclusive or" Operator" : Toán tử XOR thực hiện phép toán logic "hoặc loại trừ".
        void XOR()
        {
            bool a = true;
            bool b = false;
            bool result = a ^ b;
            Console.WriteLine(result); // Kết quả: true
        }

        // default : Toán tử default trả về giá trị mặc định của một kiểu dữ liệu.
        void Default()
        {
            int defaultInt = default(int);
            string defaultString = default(string);
            Console.WriteLine($"Default int: {defaultInt}, Default string: {defaultString ?? "null"}");
        }

        // Assignment: Toán tử gán null coalescing gán giá trị cho biến nếu biến đó là null.
        void Assignment()
        {
            string message = null;
            message ??= "Xin chào";
            Console.WriteLine(message);
        }

        // sizeof: Toán tử sizeof trả về kích thước của một kiểu dữ liệu trong bộ nhớ.
        void SizeOf()
        {
            Console.WriteLine($"Kích thước của int: {sizeof(int)} bytes");
            Console.WriteLine($"Kích thước của long: {sizeof(long)} bytes");
        }

        // ?? Null-Coalescing Operator: Toán tử null-coalescing trả về giá trị bên trái nếu nó không null, ngược lại trả về giá trị bên phải.
        void NullCoalescing2()
        {
            string input = null;
            string result = input ?? "Giá trị mặc định";
            Console.WriteLine(result);
        }

        // Bit-Shifting Operators: Toán tử dịch bit cho phép dịch chuyển các bit sang trái hoặc phải.
        void BitShifting()
        {
            int number = 8;  // 1000 in binary
            int leftShift = number << 1;  // 10000 in binary (16 in decimal)
            int rightShift = number >> 1; // 100 in binary (4 in decimal)
            Console.WriteLine($"Left shift: {leftShift}, Right shift: {rightShift}");
        }

        // => Lambda operator : Toán tử lambda được sử dụng để định nghĩa các biểu thức lambda hoặc phương thức ngắn gọn.
        void Lambda()
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
        }

        // Class Member Operators: Null Conditional Member Access: Toán tử truy cập thành viên có điều kiện null cho phép truy cập an toàn vào các thành viên của đối tượng có thể null.
        class Person2
        {
            public string Name { get; set; }
        }
     
        void ClassMember()
        {
            Person2 person = null;
            string name = person?.Name;
            Console.WriteLine(name ?? "Không có tên");
        }

        // Class Member Operators: Null Conditional Indexing: Toán tử chỉ mục có điều kiện null cho phép truy cập an toàn vào các phần tử của mảng hoặc collection có thể null.
        void ConditionalIndexing()
        {
            string[] names = null;
            string firstItem = names?[0];
            Console.WriteLine(firstItem ?? "Mảng rỗng hoặc null");
        }

        // Postfix and Prefix increment and decrement: Toán tử tăng và giảm tiền tố và hậu tố được sử dụng để tăng hoặc giảm giá trị của biến.
        void Postfix()
        {
            int a = 5;
            Console.WriteLine(a++); // Hiển thị 5, sau đó a = 6
            Console.WriteLine(++a); // a = 7, sau đó hiển thị 7
        }

        // typeof: Toán tử typeof trả về đối tượng System.Type của một kiểu dữ liệu.
        void TypeOf() 
        {
            Type stringType = typeof(string);
            Console.WriteLine($"Tên đầy đủ của kiểu string: {stringType.FullName}");
        }

        // Binary operators with assignment: 
        void Ex19()
        {
            int x = 10;
            x += 5; // Tương đương với x = x + 5
            Console.WriteLine(x);
        }

        // nameof Operator:  Toán tử nameof trả về tên của một biến, kiểu, hoặc thành viên dưới dạng chuỗi.
        void Ex20()
        {
            int count = 5;
            Console.WriteLine(nameof(count)); // Hiển thị "count"
        }

        // Class Member Operators: Member Access: Toán tử truy cập thành viên được sử dụng để truy cập các thuộc tính và phương thức của một đối tượng.
        class MyClass
        {
            public int MyProperty { get; set; }
            public void MyMethod() { }
        }

        void Ex21()
        {
            MyClass obj = new MyClass();
            obj.MyProperty = 10;
            obj.MyMethod();
        }

        // Class Member Operators: Function Invocation: Toán tử gọi hàm được sử dụng để thực thi các phương thức.
        void Ex22()
        {
            static int Add(int a, int b) => a + b;

            int result = Add(3, 4);
            Console.WriteLine(result);
        }

        // Class Member Operators: Aggregate Object Indexing: Toán tử chỉ mục đối tượng tổng hợp được sử dụng để truy cập các phần tử trong các collection hoặc mảng.
        void Ex23()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int thirdNumber = numbers[2];
            Console.WriteLine(thirdNumber);
        }
    }
}
