﻿public class BinaryHeap
{
    // Макс-куча - значение в вершине больше или равно значениям в потомках
    // Мин-куча - значение в вершине меньше или равно значениям в потомках

    // Макс-куча

    // GetMax - корень

    // Insert - подвесить к листу новую вершину, просеять вверх
    // Просеять вверх :
    // 1) на каждом шаге поддерживается инвариант - свойство кучи нарушается только на одном ребре
    // 2) меняем вершины с этим инвариантом
    // 3) повторяем пока свойство не востановится

    // ExtractMax - обменять корень с листом, просеять вниз
    // Просеять вниз :
    // 1) Свойство кучи нарушено ровно в одной вершине 
    // 2) Из потомков этой вершины выбирается максимальный
    // 3) С ним происходит обмен
    // 4) Повторить пока свойство не востановится

    // ChangePriority - изменить приоритет в указанной вершине, в зависимости от изменения просеять вверх или вниз

    // Remove - изменить приоритет в указанной вершине на inf, просеять вверх, извлечь максимум

    // Тогда все операции будут иметь время O(высота дерева)


    // Поддерживать хорошую высоту дерева можно заполняя каждый ряд слева на право, не пропуская ни одного потомка

    // Тогда дерево имеет высоту O(log(кол-во элементов))

    // Удобно хранить в массиве (array) ((нумерация от единицы))
    // Parent(i) = array[i/2] (целочисленное деление)
    // LeftChild(i) = array[2i]
    // RightChild(i) = array[2i + 1]

    // Как поддерживать такое построение :
    // Insert - вставка на первое свободное место на последнем уровне
    // ExtractMax - обменивать с последним занятым местом на последнем уровне

    // Массив H: (Heap) ((нумерация от единицы))
    // Size - Граница, до которой включительно лежат элементы кучи
    // MaxSize - Актуальный размер массива

    // Parent(i) : return H[i/2]
    // Left(i) : return H[2i] <- очевидно пока 2i <= size
    // Rigth(i) : return H[2i+1] <- очевидно пока 2i + 1 <= size

    /* SiftUp(i):
     * while(i > 1 and H[i] > Parent(i))
     *  swap(H[i], Parent(i))
     *  i = i/2
     *
     *
     *
     * SiftDown(i):
     * while(i <= size and (H[i] < Left(i) || H[i] < Rigth(i))
     *  temp = IndexOf(Max(Left(i), Rigth(i))
     *  swap(H[i], H[temp])
     *  i = temp
     *  
     *  
     * Insert(p):
     * if(size == MaxSize)
     *  return error
     * size = size + 1
     * H[size] = p
     * SiftUp(size)
     * 
     * ExtractMax():
     * result = H[1]
     * H[1] = H[size]
     * SiftDown(1)
     * return result
     * 
     * Remove(i):
     * H[i] = inf
     * SiftUp(i)
     * ExtractMax()
     * 
     * ChangePriority(i,p):
     * oldP = H[i]
     * H[i] = p
     * if(p < oldP)
     *  SiftDown(i)
     * else
     *  SiftUp(i)
     */
}

