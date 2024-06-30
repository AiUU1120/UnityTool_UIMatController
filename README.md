# UnityTool_UIGray
### 一个可以同时将物体上所有子物体的UI组件变灰的工具
- 总所周知，UGUI的组件都继承自`Graphic`类
- 利用这一点，我们可以使用`GetComponentsInChildren<Graphic>()`方法来获取物体上所有子物体的UI组件
- 然后使用一个灰度Shader，通过简单的Set操作调用方法改变所有Graphic的material属性即可
