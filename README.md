# unity-test-task
### ЗАДАНИЕ 1. [Выполнено]
Сделать генератор mesh трехмерного объекта из 6x6x6 кубов. В скрипт передается массив который содержит информацию о том какие из кубов существуют. 
#### MeshGenerator.cs

### ЗАДАНИЕ 2. [Выполнено]
Сетевая игра через photon pun. Персонаж двигается, по кнопке меняется цвет у объекта взаимодействия. 
#### InputManager.cs, папка Player/ и папка Interactable/
Добавлены движение персонажа (WASD) и осмотр от первого лица (Мышь). Добавлен интерактивный объект и взаимодействие (Пробел).
#### Папка Infastructure/
Сетевая часть используя photon pun 2. В редакторе юнити запускать игру следует со сцены Loading. В билд версии сцены загружаются в нужном порядке. Следующая за Loading сцена Lobby. Функции создания или присоединения к комнате по имени введенному в текстовое поле.
