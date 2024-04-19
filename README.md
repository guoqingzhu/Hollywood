## Hollywood demo

* 开发用的unity版本号：2022.3.17f1c1

* 部分对话内容以csv的形式保存在本地 Resources/Data 文件夹中

* 几乎所有的UI元素都制作成了prefab, 存放在 Resources/Prefabs 文件夹中，对应的脚本都挂在prefab上

* 脚本文件按照场景放在不同的文件夹上


## 几个比较重要的脚本

* UIManager UI显示和界面跳转
* NetManager 网络通信
* EventManager 游戏内消息通知
* MainNotification 主界面上显示游戏内的通知
* readCSV 读取本地csv文件
* Guide demo的入口