using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCameraControlScript : MonoBehaviour
{
    private GameObject pintTarget;       //ターゲット格納用

    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[,] textDataBox; //テキストの複数列を入れる2次元は配列 

    private int rowLength; //テキスト内の行数を取得する変数
    private int columnLength; //テキスト内の列数を取得する変数
    [SerializeField]
    private Vector3 pointPotion; //
    float turnTime = 0.1f;

    // Start is called before the first frame update
    private void setMapData()
    {
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("mapdata", typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n');
        //行数と列数を取得
        columnLength = textMessage[0].Split(',').Length;
        rowLength = textMessage.Length - 1;
        //2次配列を定義
        textDataBox = new string[rowLength, columnLength];
        for (int i = 0; i < rowLength; i++)
        {
            string[] tempWords = textMessage[i].Split(','); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入
            for (int n = 0; n < columnLength; n++)
            {
                textDataBox[i, n] = tempWords[n]; //2次配列textWordsにカンマごとに分けたtextDataBoxを代入していく
            }
        }
    }
    void Start()
    {
        setMapData();
        pintTarget = GameObject.Find("CameraControler");
        pointPotion.x = 0;
        pointPotion.y = 0.5f + 0.5f * int.Parse(textDataBox[0,0]);
        pointPotion.z = 0;
        this.transform.position = pointPotion;
    }

    // Update is called once per frame
    void Update()
    {

        //テキストの数値に合わせてY軸の変更
        //XZ平面移動はそのままでいけそうだが最大値と初期位置はテキストから読み取った配列を参照
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!(pointPotion.x < 1))
            {
                pointPotion.x -= 1;
                pointPotion.y = 0.5f + 0.5f * int.Parse(textDataBox[(int)pointPotion.z, (int)pointPotion.x]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!(pointPotion.x > columnLength - 2 ))
            {
                pointPotion.x += 1;
                pointPotion.y = 0.5f + 0.5f * int.Parse(textDataBox[(int)pointPotion.z, (int)pointPotion.x]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!(pointPotion.z > rowLength - 2))
            {
                pointPotion.z += 1;
                pointPotion.y = 0.5f + 0.5f * int.Parse(textDataBox[(int)pointPotion.z, (int)pointPotion.x]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!(pointPotion.z < 1))
            {
                pointPotion.z -= 1;
                pointPotion.y = 0.5f + 0.5f * int.Parse( textDataBox[(int)pointPotion.z, (int)pointPotion.x]);
            }
        }
        //ポジションをLerpで移動
        this.transform.position = Vector3.Lerp(this.transform.position, pointPotion, Time.deltaTime / turnTime);

    }
}
