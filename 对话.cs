using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class 对话 : MonoBehaviour
{
    public TextAsset text;//文本文件
    public GameObject chararcterleft;
    public GameObject chararcterright;

    public Button next;

   public GameObject obtionbutton;///预制体选项按钮

    public Transform buttongroup;///选项按钮父节点，用来排序

    public List<Sprite> sprites = new List<Sprite>();
    /// <summary>
    /// 图片合集
    /// </summary>
    public Image[] gameObjects;

    public int diaIndex;///用来保存对话索引值

    public string[] diaRow;

    public Dictionary<string, Sprite> iction = new Dictionary<string, Sprite>();//角色名称对应图片
    public TMP_Text nametext;
    //角色名字
    public TMP_Text diatext;
    //对话框文本

    // Start is called before the first frame update

    private void Awake()
    {
       

        iction["NPC"] = sprites[0];
        iction["你"] = sprites[1];

        gameObjects[0].sprite = sprites[0];
        gameObjects[1].sprite = sprites[1];
    }

    void Start()
    {

        next.onClick.AddListener(() => {


            Nextbutton();
        
        
        }
        );

        ReadText(text);
        ShowDiaRow();
        //Updatetexe("你","如何");
        //UpdateImage("NPC",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Updatetexe(string name,string text) { 
    
        nametext.text = name;

        diatext.text = text;
      

    }

   
    public void UpdateImage(string name,string imageleft) {

        if (imageleft == "左")
        {

            gameObjects[0].sprite = iction[name];

        }
        else if(imageleft == "右") {

            gameObjects[1].sprite = iction[name];

        }
    
    
    }

    public void ReadText(TextAsset textAsset) {


        diaRow = textAsset.text.Split('\n');
        //foreach (var rows in row) {

        //    string[] cell = rows.Split(',');
        
        //}

        
    }


    public void ShowDiaRow() {

        for (int i = 0;i<diaRow.Length;i++) {

            string[] cell = diaRow[i].Split(',');

            if (cell[0] == "#" && int.Parse(cell[1]) == diaIndex) {
                next.gameObject.SetActive(true);
                Updatetexe(cell[2], cell[4]);
                UpdateImage(cell[2], cell[3]);
                diaIndex = int.Parse(cell[5]);
              
                break;
            }
            else if (cell[0] == "&" && int.Parse(cell[1]) == diaIndex)
            {
                next.gameObject.SetActive(false);

                GenerateOption(i);

            }


        }
    
    }

    public void Nextbutton() {


        ShowDiaRow();
}
    public void GenerateOption(int index)
    {
        string[] cells = diaRow[index].Split(",");

        if (cells[0] == "&") {


            GameObject button = Instantiate(obtionbutton, buttongroup);

            button.GetComponentInChildren<TMP_Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener(
                delegate {

                    OnoptionClick(int.Parse(cells[5]));
                
                }


                );

        GenerateOption(index+1);
        }


    }
    public void OnoptionClick(int id) {

        diaIndex = id;
        ShowDiaRow();

        for (int i = 0;i<buttongroup.childCount;i++) {

            Destroy(buttongroup.GetChild(i).gameObject);
        
        }
    }

}
