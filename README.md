功能: 魔法存储智能拾取(存储里面有的东西直接进入存储而不是背包), 就是更好的体验里面的智能拾取.
主要是不想背包整天被塞爆，参考MagicStoragevoidbag，给MagicStorage添加一个智能拾取的远程访问器
第一次搞mod，现学现用，不保证没bug  

因为判断是否存在 用的是魔法存储自带的判断能否堆叠函数, 所以不支持不可堆叠的东西

core： Items already in storage go directly into storage when pickup
