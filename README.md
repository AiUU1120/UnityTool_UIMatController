# UnityTool_UIMatController
### 同时更改物体上所有子物体的UI组件材质
- 由于UGUI的组件都继承自`Graphic`类，利用用`GetComponentsInChildren<Graphic>()`方法来获取物体上所有子物体的UI组件
- 赋值需要的Shader给脚本，通过简单的Set操作调用方法改变所有Graphic的material属性即可
- 例：将脚本挂载在父物体上，给脚本赋一个灰度Shader，即可达到将父物体下UI同时变灰的效果
