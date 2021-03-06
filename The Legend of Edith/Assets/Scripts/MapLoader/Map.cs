//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.18444
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;

namespace MapReader {
	public class Map {

		public List<Tileset> tilesets;
		public List<Layer> layers;
		public List<ObjectGroup> objectGroups;

		public int width;
		public int height;
		public int tileWidth;
		public int tileHeight;

		public Dictionary<String, String> properties;

		public Map (XmlDocument document) {
			tilesets = new List<Tileset>();
			properties = new Dictionary<String, String>();
			
			XmlNode mapNode = document ["map"];

			width = int.Parse(mapNode.Attributes ["width"].Value);
			height = int.Parse(mapNode.Attributes ["height"].Value);
			tileWidth = int.Parse(mapNode.Attributes ["tilewidth"].Value);
			tileHeight = int.Parse(mapNode.Attributes ["tileheight"].Value);

			layers = new List<Layer>();
			objectGroups = new List<ObjectGroup>();

			XmlNode propertiesNode = mapNode.SelectSingleNode("properties");
			if (propertiesNode != null) {
				XmlNodeList propertyNodes = propertiesNode.SelectNodes("property");
				if (propertyNodes != null) {
					foreach (XmlNode node in propertyNodes) {
						String name = node.Attributes["name"].Value;
						String value = node.Attributes["value"].Value;
						
						properties.Add(name, value);
					}
				}
			}
			
			XmlNodeList tilesetNodes = mapNode.SelectNodes("tileset");

			foreach (XmlNode tilesetNode in tilesetNodes) {
				Tileset tileset = new Tileset(tilesetNode);
				tilesets.Add(tileset);
			}

			XmlNodeList layerNodes = mapNode.SelectNodes("layer");
			foreach (XmlNode layerNode in layerNodes) {
				Layer layer = new Layer(layerNode);
				layers.Add (layer);
			}

			XmlNodeList objectGroupNodes = mapNode.SelectNodes ("objectgroup");
			foreach (XmlNode objectGroupNode in objectGroupNodes) {
				ObjectGroup objectGroup = new ObjectGroup(objectGroupNode);
				objectGroups.Add(objectGroup);
			}
		}
		
		public Tileset GetTileset(int gid) {
			foreach (Tileset t in tilesets) {
				if (gid >= t.getFirstGid() && gid <= t.getLastGid()) {
					return t;
				}
			}
			
			return null;
		}
	}
}