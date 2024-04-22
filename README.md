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

## 项目结构

    -Assets
    --Resources
        ---Data 本地数据表格（一些本地的对话保存在这里）
        ---images 图片资源（按照场景分文件夹）
        ---Prefabs 所有场景UI的预制件
        ---spine spine文件
    --Scenes 目前只有一个main场景作为入口，其他页面以prefab的形式加载
    --Scripts
        ---Audition 拍摄界面的脚本
        ---Common 通用代码脚本
        ---Contact 联系人界面的脚本
        ---Dwitter 社交界面的脚本
        ---Map 地图界面的脚本
        ---UI 通用UI组件的脚本
        ---Wecaht 聊天界面的脚本
    --Spine //spine支持插件
