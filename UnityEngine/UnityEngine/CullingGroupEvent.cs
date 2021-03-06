﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.CullingGroupEvent
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

namespace UnityEngine
{
  /// <summary>
  ///   <para>Provides information about the current and previous states of one sphere in a CullingGroup.</para>
  /// </summary>
  public struct CullingGroupEvent
  {
    private const byte kIsVisibleMask = 128;
    private const byte kDistanceMask = 127;
    private int m_Index;
    private byte m_PrevState;
    private byte m_ThisState;

    /// <summary>
    ///   <para>The index of the sphere that has changed.</para>
    /// </summary>
    public int index
    {
      get
      {
        return this.m_Index;
      }
    }

    /// <summary>
    ///   <para>Was the sphere considered visible by the most recent culling pass?</para>
    /// </summary>
    public bool isVisible
    {
      get
      {
        return ((int) this.m_ThisState & 128) != 0;
      }
    }

    /// <summary>
    ///   <para>Was the sphere visible before the most recent culling pass?</para>
    /// </summary>
    public bool wasVisible
    {
      get
      {
        return ((int) this.m_PrevState & 128) != 0;
      }
    }

    /// <summary>
    ///   <para>Did this sphere change from being invisible to being visible in the most recent culling pass?</para>
    /// </summary>
    public bool hasBecomeVisible
    {
      get
      {
        if (this.isVisible)
          return !this.wasVisible;
        return false;
      }
    }

    /// <summary>
    ///   <para>Did this sphere change from being visible to being invisible in the most recent culling pass?</para>
    /// </summary>
    public bool hasBecomeInvisible
    {
      get
      {
        if (!this.isVisible)
          return this.wasVisible;
        return false;
      }
    }

    /// <summary>
    ///   <para>The current distance band index of the sphere, after the most recent culling pass.</para>
    /// </summary>
    public int currentDistance
    {
      get
      {
        return (int) this.m_ThisState & (int) sbyte.MaxValue;
      }
    }

    /// <summary>
    ///   <para>The distance band index of the sphere before the most recent culling pass.</para>
    /// </summary>
    public int previousDistance
    {
      get
      {
        return (int) this.m_PrevState & (int) sbyte.MaxValue;
      }
    }
  }
}
