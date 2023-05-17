Person user = new Person("プロ太", 30);
Console.WriteLine(user.Name); //「プロ太」と表示される
// user.Name = "プロ子"; //これはコンパイルエラーになる
Console.WriteLine(user.Age); //30と表示される
user.Age = 31; //ageを31に更新する
user.Age = -1; //「エラー：…」と表示され、ageは更新されない

class Person
{
    private string? name;
    private int age;

    //★(a) コンストラクタ
    public Person(string? name, int age)
    {
        this.name = name;
        this.age = age;
    }

    //★(b1) プロパティ (読み取りのみ)
    public string? Name
    {
        get { return name; }
    }

    //★(b2) プロパティ (読み取り/書き込み両方)
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("エラー：年齢に0未満の値を設定することはできません");
            }
            else
            {
                age = value;
            }
        }
    }
}