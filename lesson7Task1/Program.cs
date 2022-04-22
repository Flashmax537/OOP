using System;

namespace lesson7Task1
{
    class Program
    {
        static void Main()
        {
            var originalString = "абпюя АБПЮЯ abmyz ABMYZ";

            Console.WriteLine("ACoder:");
            var ACoder = new ACoder(originalString);
            Console.WriteLine($"Origin = {originalString}");
            Console.WriteLine($"Encode = {ACoder.Encode()}");
            Console.WriteLine($"Decode = {ACoder.Decode()}");

            Console.WriteLine("\nBCoder:");
            var BCoder = new BCoder(originalString);
            Console.WriteLine($"Origin = {originalString}");
            Console.WriteLine($"Encode = {BCoder.Encode()}");
            Console.WriteLine($"Decode = {BCoder.Decode()}");
        }
    }

    public interface IСoder
    {
        /// <summary>
        /// Шифрование строк
        /// </summary>
        public string Encode();

        /// <summary>
        /// Дешифрование строк
        /// </summary>
        public string Decode();
    }

    /// <summary>
    /// Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше
    /// </summary>
    public class ACoder : IСoder
    {
        /// <summary>
        /// Входной массив символов
        /// </summary>
        private readonly char[] _inputCharArray;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ACoder() { }

        public ACoder(string inputString)
        {
            _inputCharArray = inputString.ToCharArray();
        }

        public string Decode()
        {
            for (int i = 0; i < _inputCharArray.Length; i++)
            {
                switch (_inputCharArray[i])
                {
                    case (char)1040: 
                        _inputCharArray[i] = (char)(1071);
                        break;

                    case (char)1072: 
                        _inputCharArray[i] = (char)(1103);
                        break;

                    case (char)97: 
                        _inputCharArray[i] = (char)(122);
                        break;

                    case (char)65: 
                        _inputCharArray[i] = (char)(90);
                        break;

                    default:
                        if ((char)1071 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1040 // русские заглавные
                            || (char)1103 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1072 // русские строчные
                            || (char)122 >= _inputCharArray[i] && _inputCharArray[i] >= (char)97 // английские строчные
                            || (char)90 >= _inputCharArray[i] && _inputCharArray[i] >= (char)65) // английские заглавные
                            _inputCharArray[i] = (char)(_inputCharArray[i] - 1);
                        else
                        {
                            _inputCharArray[i] = _inputCharArray[i];
                        }
                        break;
                }
            }

            return string.Concat(_inputCharArray);
        }

        public string Encode()
        {
            for (int i = 0; i < _inputCharArray.Length; i++)
            {
                switch (_inputCharArray[i])
                {
                    case (char)1071:
                        _inputCharArray[i] = (char)(1040);
                        break;

                    case (char)1103:
                        _inputCharArray[i] = (char)(1072);
                        break;

                    case (char)122:
                        _inputCharArray[i] = (char)(97);
                        break;

                    case (char)90:
                        _inputCharArray[i] = (char)(65);
                        break;

                    default:
                        if ((char)1071 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1040 // русские заглавные
                            || (char)1103 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1072 // русские строчные
                            || (char)122 >= _inputCharArray[i] && _inputCharArray[i] >= (char)97 // английские строчные
                            || (char)90 >= _inputCharArray[i] && _inputCharArray[i] >= (char)65) // английские заглавные
                            _inputCharArray[i] = (char)(_inputCharArray[i] + 1);
                        else
                        {
                            _inputCharArray[i] = _inputCharArray[i];
                        }
                        break;
                }
            }

            return string.Concat(_inputCharArray);
        }
    }

    /// <summary>
    /// Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра, расположенную в алфавите на i - й позиции с конца алфавита
    /// </summary>
    public class BCoder : IСoder
    {
        /// <summary>
        /// Входной массив символов
        /// </summary>
        private readonly char[] _inputCharArray;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BCoder() { }

        public BCoder(string inputString)
        {
            _inputCharArray = inputString.ToCharArray();
        }

        public string Encode()
        {
            for (int i = 0; i < _inputCharArray.Length; i++)
            {
                if ((char)1071 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1040) // русские заглавные
                    _inputCharArray[i] = (char)(1071 - (_inputCharArray[i] - 1040));

                if ((char)1103 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1072) // русские строчные
                    _inputCharArray[i] = (char)(1103 - (_inputCharArray[i] - 1072));

                if ((char)122 >= _inputCharArray[i] && _inputCharArray[i] >= (char)97) // английские строчные
                    _inputCharArray[i] = (char)(122 - (_inputCharArray[i] - 97));

                if ((char)90 >= _inputCharArray[i] && _inputCharArray[i] >= (char)65) // английские заглавные
                    _inputCharArray[i] = (char)(90 - (_inputCharArray[i] - 65));
                else
                {
                    _inputCharArray[i] = _inputCharArray[i];
                }
            }
            return string.Concat(_inputCharArray);
        }

        public string Decode()
        {
            for (int i = 0; i < _inputCharArray.Length; i++)
            {
                if ((char)1071 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1040) // русские заглавные
                    _inputCharArray[i] = (char)(1071 - (_inputCharArray[i] - 1040));

                if ((char)1103 >= _inputCharArray[i] && _inputCharArray[i] >= (char)1072) // русские строчные
                    _inputCharArray[i] = (char)(1103 - (_inputCharArray[i] - 1072));

                if ((char)122 >= _inputCharArray[i] && _inputCharArray[i] >= (char)97) // английские строчные
                    _inputCharArray[i] = (char)(122 - (_inputCharArray[i] - 97));

                if ((char)90 >= _inputCharArray[i] && _inputCharArray[i] >= (char)65) // английские заглавные
                    _inputCharArray[i] = (char)(90 - (_inputCharArray[i] - 65));
                else
                {
                    _inputCharArray[i] = _inputCharArray[i];
                }

            }
            return string.Concat(_inputCharArray);
        }
    }
}
