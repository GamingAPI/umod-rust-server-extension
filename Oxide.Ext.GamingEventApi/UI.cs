using Oxide.Game.Rust.Cui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Oxide.Ext.GamingEventApi
{
    public class UI
    {
        public static string HexToRGBA(string hex, float alpha)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.TrimStart('#');
            }

            int red = int.Parse(hex.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            int green = int.Parse(hex.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            int blue = int.Parse(hex.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            return $"{(double)red / 255} {(double)green / 255} {(double)blue / 255} {alpha}";
        }

        static public CuiElementContainer CreateElementContainer(string panelName, string color, CuiRectTransformComponent anchor, bool cursor = false)
        {
            return CreateElementContainer(panelName, color, anchor.AnchorMin, anchor.AnchorMax, cursor);
        }
        
        static public CuiElementContainer CreateElementContainer(string panelName, string color, string aMin, string aMax, bool cursor = false)
        {
            return new CuiElementContainer()
            {
                {
                    new CuiPanel
                    {
                        Image = {Color = color},
                        RectTransform = {AnchorMin = aMin, AnchorMax = aMax},
                        CursorEnabled = cursor
                    },
                    new CuiElement().Parent,
                    panelName
                }
            };
        }
        #region Panels
        static public CuiPanel CreatePanel(string color, string aMin, string aMax, bool cursor = false)
        {
            return new CuiPanel
            {
                Image = { Color = color },
                RectTransform = { AnchorMin = aMin, AnchorMax = aMax },
                CursorEnabled = cursor
            };
        }
        static public CuiPanel CreatePanel(string color, CuiRectTransformComponent anchor, bool cursor = false)
        {
            return CreatePanel(color, anchor.AnchorMin, anchor.AnchorMax, cursor);
        }
        static public void CreatePanel(ref CuiElementContainer container, string panel, string color, CuiRectTransformComponent anchor, bool cursor = false)
        {
            CreatePanel(ref container, panel, color, anchor.AnchorMin, anchor.AnchorMax, cursor);
        }
        static public void CreatePanel(ref CuiElementContainer container, string panel, string color, string aMin, string aMax, bool cursor = false)
        {
            container.Add(CreatePanel(color, aMin, aMax, cursor), panel);
        }
        #endregion

        #region Labels
        static public CuiLabel CreateLabel(string color, string text, int size, string aMin, string aMax, TextAnchor align = TextAnchor.MiddleCenter)
        {
            return new CuiLabel
            {
                Text = { Color = color, FontSize = size, Align = align, FadeIn = 1.0f, Text = text },
                RectTransform = { AnchorMin = aMin, AnchorMax = aMax }
            };
        }
        static public CuiLabel CreateLabel(string color, string text, int size, CuiRectTransformComponent anchor, TextAnchor align = TextAnchor.MiddleCenter)
        {
            return CreateLabel(color, text, size, anchor.AnchorMin, anchor.AnchorMax, align);
        }
        static public void CreateLabel(ref CuiElementContainer container, string panel, string color, string text, int size, CuiRectTransformComponent anchor, TextAnchor align = TextAnchor.MiddleCenter)
        {
            CreateLabel(ref container, panel, color, text, size, anchor.AnchorMin, anchor.AnchorMax, align);
        }
        static public void CreateLabel(ref CuiElementContainer container, string panel, string color, string text, int size, string aMin, string aMax, TextAnchor align = TextAnchor.MiddleCenter)
        {
            container.Add(CreateLabel(color, text, size, aMin, aMax, align), panel);
        }

        #endregion


        #region Buttons
        static public CuiButton CreateButton(string buttonColor, string textColor, string text, int size, string aMin, string aMax, string command, float fadeIn, TextAnchor align = TextAnchor.MiddleCenter)
        {
            return new CuiButton
            {
                Button = { Color = buttonColor, Command = command, FadeIn = fadeIn },
                RectTransform = { AnchorMin = aMin, AnchorMax = aMax },
                Text = { Text = text, Color = textColor, FontSize = size, Align = align }
            };
        }
        static public CuiButton CreateButton(string buttonColor, string textColor, string text, int size, string aMin, string aMax, string command, TextAnchor align = TextAnchor.MiddleCenter)
        {
            return CreateButton(buttonColor, textColor, text, size, aMin, aMax, command, 0, align);
        }
        static public CuiButton CreateButton(string color, string text, int size, string aMin, string aMax, string command, TextAnchor align = TextAnchor.MiddleCenter)
        {
            return CreateButton(color, "1 1 1 1", text, size, aMin, aMax, command, align);
        }
        static public CuiButton CreateButton(string color, string text, int size, CuiRectTransformComponent anchor, string command, TextAnchor align = TextAnchor.MiddleCenter)
        {
            return CreateButton(color, text, size, anchor.AnchorMin, anchor.AnchorMax, command, align);
        }
        static public void CreateButton(ref CuiElementContainer container, string panel, string color, string text, int size, CuiRectTransformComponent anchor, string command, TextAnchor align = TextAnchor.MiddleCenter)
        {
            CreateButton(ref container, panel, color, text, size, anchor.AnchorMin, anchor.AnchorMax, command, align);
        }
        static public void CreateButton(ref CuiElementContainer container, string panel, string color, string text, int size, string aMin, string aMax, string command, TextAnchor align = TextAnchor.MiddleCenter)
        {
            container.Add(CreateButton(color, text, size, aMin, aMax, command, align), panel);
        }
        static public void CreateButton(ref CuiElementContainer container, string panel, string color, string text, int size, string aMin, string aMax, string oMin, string oMax, string command, TextAnchor align = TextAnchor.MiddleCenter)
        {
            container.Add(new CuiButton
            {
                Button = { Color = color, Command = command, FadeIn = 1.0f },
                RectTransform = { AnchorMin = aMin, AnchorMax = aMax, OffsetMin = oMin, OffsetMax = oMax },
                Text = { Text = text, FontSize = size, Align = align }
            },
            panel);
        }
        #endregion

        #region Image
        static public CuiElement CreateImage(string panel, string img, string aMin, string aMax, string color)
        {
            if (img.StartsWith("http") || img.StartsWith("www"))
            {
                return new CuiElement
                {
                    Parent = panel,
                    Components =
                    {
                        new CuiRawImageComponent {Url = img, Sprite = "assets/content/textures/generic/fulltransparent.tga", Color = color},
                        new CuiRectTransformComponent {AnchorMin = aMin, AnchorMax = aMax }
                    }
                };
            }
            else
                return new CuiElement
                {
                    Parent = panel,
                    Components =
                    {
                        new CuiRawImageComponent {Png = img, Sprite = "assets/content/textures/generic/fulltransparent.tga", Color = color},
                        new CuiRectTransformComponent {AnchorMin = aMin, AnchorMax = aMax }
                    }
                };
        }
        static public CuiElement CreateImage(string panel, string img, CuiRectTransformComponent anchor, string color)
        {
            return CreateImage(panel, img, anchor.AnchorMin, anchor.AnchorMax, color);
        }
        static public CuiElement CreateImage(string panel, string img, CuiRectTransformComponent anchor)
        {
            return CreateImage(panel, img, anchor.AnchorMin, anchor.AnchorMax);
        }
        static public CuiElement CreateImage(string panel, string img, string aMin, string aMax)
        {
            return CreateImage(panel, img, aMin, aMax, "1.0 1.0 1.0 1.0");
        }

        static public void CreateImage(ref CuiElementContainer container, string panel, string img, string aMin, string aMax)
        {
            container.Add(CreateImage(panel, img, aMin, aMax));
        }
        #endregion

        static public void CreateTextOverlay(ref CuiElementContainer element, string panel, string text, string color, int size, string aMin, string aMax, TextAnchor align = TextAnchor.MiddleCenter, float fadein = 1.0f)
        {
            //if (configdata.DisableUI_FadeIn)
            //    fadein = 0;
            element.Add(new CuiLabel
            {
                Text = { Color = color, FontSize = size, Align = align, FadeIn = fadein, Text = text },
                RectTransform = { AnchorMin = aMin, AnchorMax = aMax }
            },
            panel);

        }

        static public void CreateTextOutline(ref CuiElementContainer element, string panel, string colorText, string colorOutline, string text, int size, string aMin, string aMax, TextAnchor align = TextAnchor.MiddleCenter)
        {
            element.Add(new CuiElement
            {
                Parent = panel,
                Components =
                    {
                        new CuiTextComponent{Color = colorText, FontSize = size, Align = align, Text = text },
                        new CuiOutlineComponent {Distance = "1 1", Color = colorOutline},
                        new CuiRectTransformComponent {AnchorMax = aMax, AnchorMin = aMin }
                    }
            });
        }
    }
}
