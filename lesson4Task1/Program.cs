using System;

namespace lesson4Task1
{
    class Program
    {
        static void Main()
        {
            var buildingOne = new Building();
            buildingOne.SetHeight(25);
            buildingOne.SetFloorСount(10);
            buildingOne.SetApartmentsCount(300);
            buildingOne.SetEntrancesCount(3);
            var buildingTwo = new Building();
            buildingTwo.SetHeight(15);
            buildingTwo.SetFloorСount(5);
            buildingTwo.SetApartmentsCount(150);
            buildingTwo.SetEntrancesCount(3);
            var buildingThree = new Building();
            buildingThree.SetHeight(6.6);
            buildingThree.SetFloorСount(3);
            buildingThree.SetApartmentsCount(60);
            buildingThree.SetEntrancesCount(2);

            PrintBuildingInfo(buildingOne);
            PrintBuildingInfo(buildingTwo);
            PrintBuildingInfo(buildingThree);
        }

        /// <summary>
        /// Вывод информации о здании
        /// </summary>
        /// <param name="building">Здание</param>
        public static void PrintBuildingInfo(Building building)
        {
            Console.WriteLine($"Уникальный номер здания: {building.Id}");
            Console.WriteLine($"Высота этажа: {building.GetFloorHeights(building.GetHeight(), building.GetFloorСount())}");
            Console.WriteLine($"Количество квартир в подъезде: {building.GetCountApartmentsInEntrance(building.GetApartmentsCount(), building.GetEntrancesCount())}");
            Console.WriteLine($"Количество квартир на этаже: {building.GetCountApartmentsInFloor(building.GetApartmentsCount(), building.GetEntrancesCount(), building.GetFloorСount())}\n");
        }
    }

    public class Building
    {
        private static int _id = 1;

        public Building()
        {
            Id = _id++;
        }

        /// <summary>
        /// Уникальный номер здания
        /// </summary>
        public int Id { get;}
        /// <summary>
        /// Высота
        /// </summary>
        private double Height { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        private int FloorСount { get; set; }
        /// <summary>
        /// Количество квартир
        /// </summary>
        private int ApartmentsCount { get; set; }
        /// <summary>
        /// Количество подъездов
        /// </summary>
        private int EntrancesCount { get; set; }

        /// <summary>
        /// Задать высоту
        /// </summary>
        /// <param name="height">Высота</param>
        public void SetHeight(double height)
        {
            Height = height;
        }

        /// <summary>
        /// Задать количество этажей
        /// </summary>
        /// <param name="floorСount">Количество этажей</param>
        public void SetFloorСount(int floorСount)
        {
            FloorСount = floorСount;
        }

        /// <summary>
        /// Задать количество квартир
        /// </summary>
        /// <param name="apartmentsCount">Количество квартир</param>
        public void SetApartmentsCount(int apartmentsCount)
        {
            ApartmentsCount = apartmentsCount;
        }

        /// <summary>
        /// Задать количество подъездов
        /// </summary>
        /// <param name="entrancesCount">Количество подъездов</param>
        public void SetEntrancesCount(int entrancesCount)
        {
            EntrancesCount = entrancesCount;
        }

        public double GetHeight()
        {
            return Height;
        }

        public int GetFloorСount()
        {
            return FloorСount;
        }

        public int GetApartmentsCount()
        {
            return ApartmentsCount;
        }

        public int GetEntrancesCount()
        {
            return EntrancesCount;
        }

        /// <summary>
        /// Получить высоту этажа
        /// </summary>
        /// <param name="height">Высота</param>
        /// <param name="floorСount">Количество этажей</param>
        /// <returns></returns>
        public double GetFloorHeights(double height, int floorСount)
        {
            return Math.Round(height / floorСount, 2);
        }

        /// <summary>
        /// Получить количество квартир в подъезде
        /// </summary>
        /// <param name="apartmentsCount">Количество квартир</param>
        /// <param name="entrancesCount">Количество подъездов</param>
        /// <returns></returns>
        public int GetCountApartmentsInEntrance(int apartmentsCount, int entrancesCount)
        {
            return apartmentsCount / entrancesCount;
        }

        /// <summary>
        /// Получить количество квартир на этаже
        /// </summary>
        /// <param name="apartmentsCount">Количество квартир</param>
        /// <param name="entrancesCount">Количество подъездов</param>
        /// <param name="floorСount">Количество этажей</param>
        /// <returns></returns>
        public int GetCountApartmentsInFloor(int apartmentsCount, int entrancesCount, int floorСount)
        {
            return (apartmentsCount / entrancesCount) / floorСount;
        }
    }
}
