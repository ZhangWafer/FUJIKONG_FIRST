using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class DataGridSpeed//主站第一排
    {
        public string 速度设置 { get; set; }
        public string 手动加减速 { get; set; }
        public string 自动加减速 { get; set; }
        public string 手动慢速 { get; set; }
        public string 手动快速 { get; set; }
        public string 自动速度 { get; set; }
        public string 复位速度 { get; set; }
        public string 最大位置 { get; set; }
       
    }

    public class dataGridSpeed3//主站
    {
        public string 速度设置 { get; set; }
        public string 放料速度 { get; set; }
        public string 收料速度 { get; set; }
        public string 备用1 { get; set; }
        public string 备用2 { get; set; }
        public string 备用3 { get; set; }
        public string 备用4 { get; set; }
        public string 备用5 { get; set; }
    }

    public class dataGridJXYS
    {
        public string 气缸延时 { get; set; }
        public string 下料破真空 { get; set; }
        public string 破真空 { get; set; }
        public string 冲床开关 { get; set; }
        public string 上位检测 { get; set; }
        public string 真空检测 { get; set; }
        public string 探针检测 { get; set; }
        public string 吸嘴真空 { get; set; }
        public string 模具吹气 { get; set; }
        
    }

    public class dataGridJP     //纠偏
    {
        public string 纠偏延时 { get; set; }
        public string 纠偏开始 { get; set; }
        public string 旋转完成 { get; set; }
        public string XY完成 { get; set; }
        public string 备用1 { get; set; }
        public string 备用2 { get; set; }
        public string 备用3 { get; set; }
        public string 备用4 { get; set; }
        public string 备用5 { get; set; }
    }

    public class dataGridGNCS  //功能参数
    {
        public string 电机系数 { get; set; }
        public string 左右系数 { get; set; }
        public string 上下系数 { get; set; }
        public string 料盘系数 { get; set; }
        public string 冲床系数 { get; set; }
        public string 隔纸前后 { get; set; }
        public string 隔纸上下 { get; set; }
        public string 备用3 { get; set; }
         
    }


    public class dataGridZuoBiao  //坐标
    {
        public string 电机坐标 { get; set; }
        public string 平台X轴 { get; set; }
        public string 平台Y轴 { get; set; }
        public string 平台Z轴 { get; set; } //真空吸气延时
        public string 左右轴 { get; set; } //
        public string 上下轴 { get; set; }  //下料等待延时
        public string 备用1 { get; set; }
        public string 备用2 { get; set; }

    }

}
