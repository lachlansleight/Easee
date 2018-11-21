# Easee

Easee is just a name I gave to my general purpose easing function that I use again and again. It's definitely not as performant as doing a normal ease (lots of unnecessary Mathf.Pow calls), but it's also a little more flexible.

# Usage
Usage is easy - there are four static functions in the Easee class. You can call Ease and specify an EaseType in your function call `EaseType.In`, `EaseType.Out`, or `EaseType.InOut`. Then you provide a positive integer power and the float parameter you want to ease.

I use this almost exclusively like this:

```C#

public IEnumerator AnimateTheThing(float from, float to, float duration)
{
  for (var i = 0f; i <= 1f; i += Time.deltaTime / duration) {
    transform.localScale = Vector3.one * Mathf.Lerp(from, to, Easee.EaseInOut(3, i));
    yield return null;
  }
  
  transform.localScale = Vector3.one * to;
}
```

Easy peasy! :)

# Installation
You can either just grab the Easee.cs file straight from the source (it's the only thing you need) or you can download one of the .unitypackage files in the Releases tab. One of them has an example scene if you enjoy watching red shiny spheres lerp back and forth.
