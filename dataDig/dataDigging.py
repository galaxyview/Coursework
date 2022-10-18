# import library
import pandas as pd
import numpy as np
import datetime as dt

import matplotlib.pyplot as plt
import seaborn as sns

from sklearn.preprocessing import StandardScaler
from sklearn.cluster import KMeans
import  warnings
warnings.filterwarnings("ignore")

#数据读取
salesOR = pd.read_csv('data.csv')

#数据格式化
salesOR_NoDup=salesOR.drop_duplicates(subset=['InvoiceNo','StockCode','Description','Quantity','InvoiceDate','UnitPrice','CustomerID','Country'])
dup=salesOR.shape[0]-salesOR_NoDup.shape[0]

#查看数据缺失情况
tab_info=pd.DataFrame(salesOR.dtypes).T.rename(index={0:'特征类型'})
tab_info=tab_info.append(pd.DataFrame(salesOR.isnull().sum()).T.rename(index={0:'缺失值数量'}))
tab_info=tab_info.append(pd.DataFrame(salesOR.isnull().sum()/salesOR.shape[0]).T.rename(index={0:'缺失值占比'}))
salesOR_NoDupNA=salesOR_NoDup.dropna(subset=['InvoiceNo','CustomerID'],how='any')

#重设数据类型
salesOR_NoDupNA['Quantity']=salesOR_NoDupNA['Quantity'].astype('float')
salesOR_NoDupNA['UnitPrice']=salesOR_NoDupNA['UnitPrice'].astype('float')
salesOR_NoDupNA['CustomerID']=salesOR_NoDupNA['CustomerID'].astype('object')

salesOR_NoDupNA['InvoiceDate']=pd.to_datetime(salesOR_NoDupNA['InvoiceDate'], errors='coerce')

#细化存储时间
salesOR_NoDupNA['Year'] = salesOR_NoDupNA['InvoiceDate'].dt.year
salesOR_NoDupNA['Month'] = salesOR_NoDupNA['InvoiceDate'].dt.month 
salesOR_NoDupNA['Date'] = salesOR_NoDupNA['InvoiceDate'].dt.date
salesOR_NoDupNA['weekday'] = salesOR_NoDupNA['InvoiceDate'].dt.weekday

#数据清洗
salesOR_NoDupNA=salesOR_NoDupNA.dropna(subset=['InvoiceNo','CustomerID','InvoiceDate'],how='any')
querySer=salesOR_NoDupNA.loc[:,'Quantity']>0
salesOR_NoDupNA=salesOR_NoDupNA.loc[querySer,:]
querySer1=salesOR_NoDupNA.loc[:,'UnitPrice']>0
salesOR_NoDupNA=salesOR_NoDupNA.loc[querySer1,:]

querySer2=salesOR_NoDupNA.loc[:,'InvoiceDate']<'2011-12-01'
salesOR_NoDupNA=salesOR_NoDupNA.loc[querySer2,:]
salesOR_NoDupNA['Amount']=salesOR_NoDupNA.Quantity*salesOR_NoDupNA.UnitPrice
Max_date=salesOR_NoDupNA.Date.max()+dt.timedelta(days=1)

#建立rfm模型，为后续K-Means算法准备
rfm=salesOR_NoDupNA.groupby(['CustomerID']).agg({'Date':lambda x:(Max_date-x.max()).days,'InvoiceNo':'count','Amount':'sum'})
rfm.rename(columns={'Date':'Recency','InvoiceNo':'Frequency','Amount':'Monetary'},inplace=True)
rfm_k=rfm[['Recency','Frequency','Monetary']]
rfm_log=rfm[['Recency','Frequency','Monetary']].apply(np.log,axis=1).round(3)
scaler = StandardScaler()
scaler.fit(rfm_log)
rfm_normalized=scaler.transform(rfm_log)

#聚类分析
ks = range(1,8)
inertias=[]
for k in ks:
    kc = KMeans(n_clusters=k, random_state=1)
    kc.fit(rfm_normalized)
    inertias.append(kc.inertia_)
#聚类分析可视化展示
f,ax = plt.subplots(figsize=(10,6))
plt.plot(ks,inertias,'-o')
plt.xlabel('Number of clusters,k')
plt.ylabel('distance')
plt.title('')
plt.show()

kc=KMeans(n_clusters=3,random_state=1)
kc.fit(rfm_normalized)
cluster_labels = kc.labels_
 
rfm_k3=rfm_k.assign(k_cluster=cluster_labels)
rfm_k3.groupby('k_cluster').agg({'Recency':'mean','Frequency':'mean','Monetary':['mean','count']}).round(0)
rfm_k3_sta=rfm_k3.groupby('k_cluster').agg({'Recency':['mean','std'],'Frequency':['mean','std'],'Monetary':['mean','std']}).round(1)
print(rfm_k3_sta) 

#绘制聚类类别的销售笔数占比
customer_num=rfm_k3.groupby('k_cluster').agg({'Recency':['count']})
fig=plt.figure(figsize=(6,9))
test=[1464,1818,1015]
labels = [u'cluster0',u'cluster1',u'cluster2']
colors=['red','yellow','green']
patches,text1,text2 = plt.pie(test,
                      labels=labels,
                      colors=colors,
                      autopct = '%3.2f%%',
                      labeldistance = 1.2,
                      shadow=False,
                      startangle=90,
                      pctdistance = 0.6)
plt.axis('equal')
plt.legend()
plt.title('Customer Segment in %')
plt.show()
fig.savefig('segmentINpercent.png')


#绘制聚类类别的销售金额占比
customer_sales=rfm_k3.groupby('k_cluster').agg({'Monetary':['sum']})
fig=plt.figure(figsize=(6,9))
test=[424560,1921626,6024025]
labels = [u'cluster0',u'cluster1',u'cluster2']
colors=['blue','dodgerblue','aquamarine']
patches,text1,text2 = plt.pie(test,
                      labels=labels,
                      colors=colors,
                      autopct = '%3.2f%%',
                      labeldistance = 1.2,
                      shadow=False,
                      startangle=90,
                      pctdistance = 0.6)




























