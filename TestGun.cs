using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomUltrakillGuns
{
    public class TestGun : MonoBehaviour
    {
		private void Start()
		{
			this.targeter = MonoSingleton<CameraFrustumTargeter>.Instance;
			this.inman = MonoSingleton<InputManager>.Instance;
			this.wid = base.GetComponent<WeaponIdentifier>();
			this.cam = MonoSingleton<CameraController>.Instance.GetComponent<Camera>();
			this.camObj = this.cam.gameObject;
			this.cc = MonoSingleton<CameraController>.Instance;
			this.nmov = MonoSingleton<NewMovement>.Instance;

			this.gunAud = base.GetComponent<AudioSource>();
			
			this.wpos = base.GetComponent<WeaponPos>();

			transform.Find("Cube").localPosition = new Vector3(-4.8951f, -4.1218f, -0.26f);
			transform.Find("Cube").gameObject.SetActive(false);
			var c = transform.Find("Cube").gameObject.AddComponent<GunColorGetter>();
			c.weaponNumber = 1000;
			c.altVersion = false;

			var mat = new Material(transform.Find("Cube").GetComponent<MeshRenderer>().materials[0]);
			var mat2 = new Material(transform.Find("Cube").GetComponent<MeshRenderer>().materials[0]);

			c.defaultMaterials = new Material[] { mat };
			c.coloredMaterials = new Material[] { mat2 };
			mat.shader = Shader.Find("psx/vertexlit/vertexlit-customcolors");
			mat.SetTexture("_IDTex", colorChangeTexture);
			//mat.SetTexture("_EmissiveTex", EmmissiveTexture);
			//mat.SetFloat("_EmissiveReplaces", 1);
			//mat.SetColor("_EmissiveColor", Color.magenta);
			mat.SetColor("_CustomColor1", Color.red);
			mat.SetColor("_CustomColor2", Color.green);
			mat.SetColor("_CustomColor3", Color.blue);

			transform.Find("Cube").gameObject.SetActive(true);

		}



		public Texture2D colorChangeTexture;
		public Texture2D EmmissiveTexture;

		private CameraFrustumTargeter targeter;
		private InputManager inman;
		private WeaponIdentifier wid;
		private Camera cam;
		private GameObject camObj;
		private CameraController cc;
		private NewMovement nmov;
		private AudioSource gunAud;
		private WeaponPos wpos;
	}
}
