namespace Csharp241011
{
	/*
	[ 인덱서 ]
	- this[]를 속성으로 정의하여 class의 instance에 index 방식으로 접근을 허용
	- get, set을 통해 동작
	*/
	internal class Indexer
	{
		class IndexerArray
		{
			private int[] array = new int[10];
			public int this[int index]
			{
				get
				{
					return array[index];
				}
				set
				{
					array[index] = value;
				}
			}
		}
		static void Test01()
		{
			IndexerArray array = new IndexerArray();

			// 인덱서를 통한 접근
			array[5] = 20;
		}
		public enum Parts { Head, Body, Feet, Hand, SIZE }
		class Equipment
		{
			string[] parts = new string[(int)Parts.SIZE];

			// 인덱서 정의
			public string this[Parts type]
			{
				get
				{
					return parts[(int)type];
				}
				set
				{
					parts[(int)type] = value;
				}
			}
		}
		static void Test02()
		{
			Equipment equipment = new Equipment();

			equipment[Parts.Head] = "낡은 뚜껑";
			equipment[Parts.Feet] = "가죽 장화";

			Console.WriteLine($"착용하고 있는 헬멧 : {equipment[Parts.Head]}");
		}
		static void Main(string[] args)
		{
			Test01();
			Test02();
		}
	}
}