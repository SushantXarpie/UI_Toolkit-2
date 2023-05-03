using System;

public interface ISavable<T>
{
    T data{get;}
    void Load(T data);
    
}