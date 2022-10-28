# class `TextureGenerator`

## Description

Draws noise or color map on a texture

## Definition

```csharp
    public static class TextureGenerator {}
```

## Functions
**TextureFromColorMap**
```csharp
    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
```

### Description
Draws texture using color map array

### Parameters

<table>
<!-- head -->
  <tr style="text-align: center">
    <td><h3>Parameter<h3></td>
    <td><h3>Type<h3></td>
    <td><h3>Description</h3></td>
  </tr>

  <tr>
    <td><code>ColorMap</code></td>
    <td><code>Color[]</code></td>
    <td>One-dimensional array of colors representing the pixel colors</td>
  </tr>
  <tr>
    <td><code>width</code></td>
    <td><code>int</code></td>
    <td>Width of texture</td>
  </tr>
  <tr>
    <td><code>height</code></td>
    <td><code>int</code></td>
    <td>Height of texture</td>
</table>

<br>

<!-- Return value  -->
### Returns : **Texture2D**

### Implementation
```csharp
public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height) {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }
```
<br>

___________________________________________________________________________________________________
<br>


**TextureFromHeightMap**
```csharp
public static Texture2D TextureFromHeightMap(float[,] heightMap)
```

### Description
Draws texture using height map (black & white)

### Parameters

<table>
<!-- head -->
  <tr style="text-align: center">
    <td><h3>Parameter<h3></td>
    <td><h3>Type<h3></td>
    <td><h3>Description</h3></td>
  </tr>

  <tr>
    <td><code>heightMap</code></td>
    <td><code>float[,]</code></td>
    <td>Two-dimensional array representing noise heights</td>
  </tr>
</table>

<br>

<!-- Return value  -->
### Returns : **Texture2D**

### Implementation
```csharp
public static Texture2D TextureFromHeightMap(float[,] heightMap) {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        // generate color array for each pixel in texture
        Color[] colorMap = new Color[width * height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }

        return TextureFromColorMap(colorMap, width, height);
    }
```













