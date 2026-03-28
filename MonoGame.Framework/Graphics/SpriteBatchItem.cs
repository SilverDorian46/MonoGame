// MonoGame - Copyright (C) MonoGame Foundation, Inc
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace Microsoft.Xna.Framework.Graphics
{
    internal class SpriteBatchItem : IComparable<SpriteBatchItem>
    {
        public Texture2D Texture;
        public float SortKey;

        public VertexPositionColorTexture vertexTL;
        public VertexPositionColorTexture vertexTR;
        public VertexPositionColorTexture vertexBL;
        public VertexPositionColorTexture vertexBR;
        public SpriteBatchItem ()
        {
            vertexTL = new VertexPositionColorTexture();
            vertexTR = new VertexPositionColorTexture();
            vertexBL = new VertexPositionColorTexture();
            vertexBR = new VertexPositionColorTexture();            
        }
        
        public void Set ( float x, float y, float dx, float dy, float w, float h, float sin, float cos, Color color, Vector2 texCoordTL, Vector2 texCoordBR, float depth )
        {
            // TODO, Should we be just assigning the Depth Value to Z?
            // According to http://blogs.msdn.com/b/shawnhar/archive/2011/01/12/spritebatch-billboards-in-a-3d-world.aspx
            // We do.
            vertexTL.Position.X = x+dx*cos-dy*sin;
            vertexTL.Position.Y = y+dx*sin+dy*cos;
            vertexTL.Position.Z = depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x+(dx+w)*cos-dy*sin;
            vertexTR.Position.Y = y+(dx+w)*sin+dy*cos;
            vertexTR.Position.Z = depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x+dx*cos-(dy+h)*sin;
            vertexBL.Position.Y = y+dx*sin+(dy+h)*cos;
            vertexBL.Position.Z = depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x+(dx+w)*cos-(dy+h)*sin;
            vertexBR.Position.Y = y+(dx+w)*sin+(dy+h)*cos;
            vertexBR.Position.Z = depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void Set(float x, float y, float w, float h, Color color, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x;
            vertexTL.Position.Y = y;
            vertexTL.Position.Z = depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x + w;
            vertexTR.Position.Y = y;
            vertexTR.Position.Z = depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x;
            vertexBL.Position.Y = y + h;
            vertexBL.Position.Z = depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x + w;
            vertexBR.Position.Y = y + h;
            vertexBR.Position.Z = depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetShear(float x, float y, float dx, float dy, float w, float h, float shX, float shY,
            Color color, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x + dx + (dy * shX);
            vertexTL.Position.Y = y + (dx * shY) + dy;
            vertexTL.Position.Z = depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x + (dx + w) + (dy * shX);
            vertexTR.Position.Y = y + ((dx + w) * shY) + dy;
            vertexTR.Position.Z = depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x + dx + ((dy + h) * shX);
            vertexBL.Position.Y = y + (dx * shY) + (dy + h);
            vertexBL.Position.Z = depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x + (dx + w) + ((dy + h) * shX);
            vertexBR.Position.Y = y + ((dx + w) * shY) + (dy + h);
            vertexBR.Position.Z = depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetShearRotate(float x, float y, float dx, float dy, float w, float h, float shX, float shY, float sin, float cos,
            Color color, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            float dx2;
            float dy2;

            dx2 = dx + (dy * shX);
            dy2 = (dx * shY) + dy;
            vertexTL.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexTL.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexTL.Position.Z = depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            dx2 = (dx + w) + (dy * shX);
            dy2 = ((dx + w) * shY) + dy;
            vertexTR.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexTR.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexTR.Position.Z = depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            dx2 = dx + ((dy + h) * shX);
            dy2 = (dx * shY) + (dy + h);
            vertexBL.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexBL.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexBL.Position.Z = depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            dx2 = (dx + w) + ((dy + h) * shX);
            dy2 = ((dx + w) * shY) + (dy + h);
            vertexBR.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexBR.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexBR.Position.Z = depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetTransformed(float x, float y, float dx, float dy, float w, float h,
            float m11, float m12, float m21, float m22,
            Color color, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x + (dx * m11) + (dy * m21);
            vertexTL.Position.Y = y + (dx * m12) + (dy * m22);
            vertexTL.Position.Z = depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x + ((dx + w) * m11) + (dy * m21);
            vertexTR.Position.Y = y + ((dx + w) * m12) + (dy * m22);
            vertexTR.Position.Z = depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x + (dx * m11) + ((dy + h) * m21);
            vertexBL.Position.Y = y + (dx * m12) + ((dy + h) * m22);
            vertexBL.Position.Z = depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x + ((dx + w) * m11) + ((dy + h) * m21);
            vertexBR.Position.Y = y + ((dx + w) * m12) + ((dy + h) * m22);
            vertexBR.Position.Z = depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetVerts(float tlX, float tlY, float trX, float trY, float blX, float blY, float brX, float brY,
            Color color, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = tlX;
            vertexTL.Position.Y = tlY;
            vertexTL.Position.Z = depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = trX;
            vertexTR.Position.Y = trY;
            vertexTR.Position.Z = depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = blX;
            vertexBL.Position.Y = blY;
            vertexBL.Position.Z = depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = brX;
            vertexBR.Position.Y = brY;
            vertexBR.Position.Z = depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetGradient(float x, float y, float dx, float dy, float w, float h, float sin, float cos,
            Color colorTL, Color colorTR, Color colorBL, Color colorBR, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x+dx*cos-dy*sin;
            vertexTL.Position.Y = y+dx*sin+dy*cos;
            vertexTL.Position.Z = depth;
            vertexTL.Color = colorTL;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x+(dx+w)*cos-dy*sin;
            vertexTR.Position.Y = y+(dx+w)*sin+dy*cos;
            vertexTR.Position.Z = depth;
            vertexTR.Color = colorTR;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x+dx*cos-(dy+h)*sin;
            vertexBL.Position.Y = y+dx*sin+(dy+h)*cos;
            vertexBL.Position.Z = depth;
            vertexBL.Color = colorBL;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x+(dx+w)*cos-(dy+h)*sin;
            vertexBR.Position.Y = y+(dx+w)*sin+(dy+h)*cos;
            vertexBR.Position.Z = depth;
            vertexBR.Color = colorBR;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetGradient(float x, float y, float w, float h,
            Color colorTL, Color colorTR, Color colorBL, Color colorBR, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x;
            vertexTL.Position.Y = y;
            vertexTL.Position.Z = depth;
            vertexTL.Color = colorTL;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x + w;
            vertexTR.Position.Y = y;
            vertexTR.Position.Z = depth;
            vertexTR.Color = colorTR;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x;
            vertexBL.Position.Y = y + h;
            vertexBL.Position.Z = depth;
            vertexBL.Color = colorBL;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x + w;
            vertexBR.Position.Y = y + h;
            vertexBR.Position.Z = depth;
            vertexBR.Color = colorBR;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetShear(float x, float y, float dx, float dy, float w, float h, float shX, float shY,
            Color colorTL, Color colorTR, Color colorBL, Color colorBR, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x + dx + (dy * shX);
            vertexTL.Position.Y = y + (dx * shY) + dy;
            vertexTL.Position.Z = depth;
            vertexTL.Color = colorTL;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x + (dx + w) + (dy * shX);
            vertexTR.Position.Y = y + ((dx + w) * shY) + dy;
            vertexTR.Position.Z = depth;
            vertexTR.Color = colorTR;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x + dx + ((dy + h) * shX);
            vertexBL.Position.Y = y + (dx * shY) + (dy + h);
            vertexBL.Position.Z = depth;
            vertexBL.Color = colorBL;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x + (dx + w) + ((dy + h) * shX);
            vertexBR.Position.Y = y + ((dx + w) * shY) + (dy + h);
            vertexBR.Position.Z = depth;
            vertexBR.Color = colorBR;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetShearRotate(float x, float y, float dx, float dy, float w, float h, float shX, float shY, float sin, float cos,
            Color colorTL, Color colorTR, Color colorBL, Color colorBR, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            float dx2;
            float dy2;

            dx2 = dx + (dy * shX);
            dy2 = (dx * shY) + dy;
            vertexTL.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexTL.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexTL.Position.Z = depth;
            vertexTL.Color = colorTL;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            dx2 = (dx + w) + (dy * shX);
            dy2 = ((dx + w) * shY) + dy;
            vertexTR.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexTR.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexTR.Position.Z = depth;
            vertexTR.Color = colorTR;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            dx2 = dx + ((dy + h) * shX);
            dy2 = (dx * shY) + (dy + h);
            vertexBL.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexBL.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexBL.Position.Z = depth;
            vertexBL.Color = colorBL;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            dx2 = (dx + w) + ((dy + h) * shX);
            dy2 = ((dx + w) * shY) + (dy + h);
            vertexBR.Position.X = x + (dx2 * cos) - (dy2 * sin);
            vertexBR.Position.Y = y + (dx2 * sin) + (dy2 * cos);
            vertexBR.Position.Z = depth;
            vertexBR.Color = colorBR;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetTransformed(float x, float y, float dx, float dy, float w, float h,
            float m11, float m12, float m21, float m22,
            Color colorTL, Color colorTR, Color colorBL, Color colorBR, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = x + (dx * m11) + (dy * m21);
            vertexTL.Position.Y = y + (dx * m12) + (dy * m22);
            vertexTL.Position.Z = depth;
            vertexTL.Color = colorTL;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = x + ((dx + w) * m11) + (dy * m21);
            vertexTR.Position.Y = y + ((dx + w) * m12) + (dy * m22);
            vertexTR.Position.Z = depth;
            vertexTR.Color = colorTR;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = x + (dx * m11) + ((dy + h) * m21);
            vertexBL.Position.Y = y + (dx * m12) + ((dy + h) * m22);
            vertexBL.Position.Z = depth;
            vertexBL.Color = colorBL;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = x + ((dx + w) * m11) + ((dy + h) * m21);
            vertexBR.Position.Y = y + ((dx + w) * m12) + ((dy + h) * m22);
            vertexBR.Position.Z = depth;
            vertexBR.Color = colorBR;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        public void SetVerts(float tlX, float tlY, float trX, float trY, float blX, float blY, float brX, float brY,
            Color colorTL, Color colorTR, Color colorBL, Color colorBR, Vector2 texCoordTL, Vector2 texCoordBR, float depth)
        {
            vertexTL.Position.X = tlX;
            vertexTL.Position.Y = tlY;
            vertexTL.Position.Z = depth;
            vertexTL.Color = colorTL;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = trX;
            vertexTR.Position.Y = trY;
            vertexTR.Position.Z = depth;
            vertexTR.Color = colorTR;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = blX;
            vertexBL.Position.Y = blY;
            vertexBL.Position.Z = depth;
            vertexBL.Color = colorBL;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = brX;
            vertexBR.Position.Y = brY;
            vertexBR.Position.Z = depth;
            vertexBR.Color = colorBR;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }

        #region Implement IComparable
        public int CompareTo(SpriteBatchItem other)
        {
            return SortKey.CompareTo(other.SortKey);
        }
        #endregion
    }
}

