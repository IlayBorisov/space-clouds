using UnityEngine;
using UnityEngine.UI;

namespace Code.Infrastructure.Services.UI
{
    [AddComponentMenu("UI/Gradient")]
    public class UIGradient : BaseMeshEffect
    {
        public Color TopColor = Color.white;
        public Color BottomColor = Color.black;

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive()) return;

            var vertices = new System.Collections.Generic.List<UIVertex>();
            vh.GetUIVertexStream(vertices);

            float minY = float.MaxValue;
            float maxY = float.MinValue;

            foreach (var vertex in vertices)
            {
                if (vertex.position.y < minY) minY = vertex.position.y;
                if (vertex.position.y > maxY) maxY = vertex.position.y;
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                UIVertex vertex = vertices[i];
                float t = (vertex.position.y - minY) / (maxY - minY);
                vertex.color = Color.Lerp(BottomColor, TopColor, t);
                vertices[i] = vertex;
            }

            vh.Clear();
            vh.AddUIVertexTriangleStream(vertices);
        }
    }
}