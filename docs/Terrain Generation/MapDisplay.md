# class `MapDisplay`

## Description

Applies texture onto a plane gameObject

## Definition

```csharp
    public static class TextureGenerator {}
```

## Fields
<table>
<!-- head -->
  <tr style="text-align: center">
    <td><h3>Field<h3></td>
    <td><h3>Type<h3></td>
    <td><h3>Description</h3></td>
  </tr>

  <tr>
    <td><code>textureRenderer</code></td>
    <td><code>Renderer</code></td>
    <td>Texture renderer</td>
  </tr>
</table>

## Functions
**DrawTexture**
```csharp
    public void DrawTexture(Texture2D texture);
```

### Description
Takes a **Texture2D** and sets it as main texture.

### Parameters

<table>
<!-- head -->
  <tr style="text-align: center">
    <td><h3>Parameter<h3></td>
    <td><h3>Type<h3></td>
    <td><h3>Description</h3></td>
  </tr>

  <tr>
    <td><code>texture</code></td>
    <td><code>Texture2D</code></td>
    <td>Texture2D object</td>
  </tr>
</table>

<br>

<!-- Return value  -->
### Returns : **Null**

### Implementation
```csharp
public void DrawTexture(Texture2D texture) {
        // allows generation without always having to enter game mode
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
```












