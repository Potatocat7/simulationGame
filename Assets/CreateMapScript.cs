using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapScript : MonoBehaviour
{

    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[,] textDataBox; //テキストの複数列を入れる2次元は配列 

    private int rowLength; //テキスト内の行数を取得する変数
    private int columnLength; //テキスト内の列数を取得する変数
    private Vector3 blockPotion; //ブロック配置用のベクター

    private void setMakeBlocks(int col,int row)
    {
        for (int i = 0; i < row; i++)
        {
            for (int n = 0; n < col; n++)
            {
                blockPotion = new Vector3(n, 0.25f*float.Parse(textDataBox[i,n]), i);
                // プレハブを取得
                GameObject Blockprefab = (GameObject)Resources.Load("MapBlock");
                // プレハブからインスタンスを生成
                Blockprefab.transform.localScale = new Vector3(1, 0.5f+0.5f*(float.Parse(textDataBox[i, n])), 1);
                Instantiate(Blockprefab, blockPotion, Quaternion.identity);
            }
        }
    }
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
 //               Debug.Log(textDataBox[i, n]);
            }
        }
        setMakeBlocks(columnLength, rowLength);

    }

    void Start()
    {
        setMapData();
    }
// Update is called once per frame
    void Update()
    {
        
    }
}
