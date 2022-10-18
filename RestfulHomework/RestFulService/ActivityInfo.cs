using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


/************************************************************************************
* Autor：xuliangxing
* Email：907562392@qq.com
* WeChart：xuliangxing
* Version：V1.0.0.0
* CreateTime：2018/4/8 13:36:40
* Description：
* Company：
* Copyright © 2018  All Rights Reserved
************************************************************************************/
namespace RestFulService
{
    public enum StateCodeEnum
    {
        SearchSuccess=4,
        CreateSuccess=1,
        ModifySuccess=2,
        DeleteSuccess=3,
        Failed=-1,
        NULL=0
    }
    [DataContract]
    public class ActivityInfo
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public StateCodeEnum StateCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int PeopleLimited { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Level { get; set; }


        public ActivityInfo()
        {
            StateCode = StateCodeEnum.SearchSuccess;
        }

        /// <summary>
        /// 根据操作结果创建具有相应状态码的ActivityInfo
        /// </summary>
        /// <param name="i">1是创建成功，2是修改成功，3是删除成功，4是查找成功返回活动信息，0是空, -1是操作失败</param>
        public ActivityInfo(StateCodeEnum sc)
        {
            switch (sc)
            {
                case StateCodeEnum.NULL:
                    StateCode = StateCodeEnum.NULL;
                    break;
                case StateCodeEnum.SearchSuccess:
                    StateCode = StateCodeEnum.SearchSuccess;
                    break;
                case StateCodeEnum.CreateSuccess:
                    StateCode = StateCodeEnum.CreateSuccess;
                    break;
                case StateCodeEnum.ModifySuccess:
                    StateCode = StateCodeEnum.ModifySuccess;
                    break;
                case StateCodeEnum.DeleteSuccess:
                    StateCode = StateCodeEnum.DeleteSuccess;
                    break;
                case StateCodeEnum.Failed:
                    StateCode = StateCodeEnum.Failed;
                    break;
                default:
                    StateCode = StateCodeEnum.NULL;
                    break;
            }
        }

    }
}
