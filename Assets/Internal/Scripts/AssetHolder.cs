using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetHolder : AssetHolderBase
{
    protected AssetHolder() { }
    static AssetHolder instance = null;
    public static AssetHolder Instance
    {
        get
        {
            if (instance == null)
                instance = new AssetHolder();

            return instance;
        }
    }


    public static void LoadAsset<Type>(string asset_name, Action<AsyncOperationHandle> callback)
    {
        Addressables.LoadAssetAsync<Type>(asset_name).Completed += 
            result =>
            {
                AllAssets.Add(asset_name, result);
                callback?.Invoke(result);
            };
        
    }
    public static void UnloadAsset<Type>(string asset_name, Action<AsyncOperationHandle?> callback)
    {
        if(!AllAssets.ContainsKey(asset_name))
        {
            callback?.Invoke(null);
            return;
        }
        Addressables.Release(AllAssets[asset_name]);
        AllAssets.Remove(asset_name);
    }
    public static void LoadScene(string scene_name, Action<AsyncOperationHandle?> callback)
    {
        Addressables.LoadSceneAsync(scene_name, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed +=
            result =>
            {
                callback?.Invoke(result);
                Addressables.Release(result);
            };
    }
}
public class AssetHolderBase
{
    static Dictionary<string, AsyncOperationHandle?> all_assets;

    public static Dictionary<string, AsyncOperationHandle?> AllAssets
    {
        get
        {
            if (all_assets == null)
                all_assets = new Dictionary<string, AsyncOperationHandle?>();

            return all_assets;
        }
        set
        {
            all_assets = value;
        }
    }
    public static bool ConfirmCreation(string asset_name)
    {
        if (!all_assets.ContainsKey(asset_name))
            throw new System.Exception($"Addressable asset with key: \"{asset_name}\" not exist!");

        if (all_assets[asset_name] == null)
            return false;

        return true;
    }
    public static bool ConfirmCreation()
    {
        foreach (string asset_key in all_assets.Keys)
            if (!ConfirmCreation(asset_key))
                return false;

        return true;
    }
}