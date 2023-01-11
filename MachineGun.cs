using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomUltrakillGuns
{
    class MachineGun : MonoBehaviour
    {
		private void Start()
		{
			this.cc = MonoSingleton<CameraController>.Instance;
			this.gunAud = base.GetComponentInChildren<AudioSource>();	
			this.gc = base.GetComponentInParent<GunControl>();

			var beam = this.shot.GetComponent<RevolverBeam>();
			var baseBeam = GetComponentInParent<GunSetter>().revolverRicochet[0].GetComponent<Revolver>().revolverBeam.GetComponent<RevolverBeam>();

			beam.hitParticle = baseBeam.hitParticle;
			beam.ricochetSound = baseBeam.ricochetSound;
			beam.enemyHitSound = baseBeam.enemyHitSound;

			gunAud.outputAudioMixerGroup = GetComponentInParent<GunSetter>().revolverRicochet[0].GetComponent<AudioSource>().outputAudioMixerGroup;
		}

		private void Update()
		{
			shootReady = cooldown <= 0;

			if (!shootReady)
            {
				cooldown -= Time.deltaTime;				
            }

			if (MonoSingleton<InputManager>.Instance.InputSource.Fire1.IsPressed && this.shootReady)
			{
				this.Shoot();
				cooldown = shootDelay;
			}
		}

		private void Shoot()
		{
			
			GameObject gameObject = Instantiate<GameObject>(this.shot, this.cc.transform.position, this.cc.transform.rotation);

			//aim assist code
			if (this.targeter.CurrentTarget && this.targeter.IsAutoAimed)
			{
				gameObject.transform.LookAt(this.targeter.CurrentTarget.bounds.center);
			}

			//shooting code i stole from the revolver
			RevolverBeam component = gameObject.GetComponent<RevolverBeam>();
			component.sourceWeapon = this.gc.currentWeapon;
			component.alternateStartPoint = this.gunBarrel.transform.position;

			//audio
			this.gunAud.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
			this.gunAud.Play();
		}

		public GameObject shot;
		public GameObject gunBarrel;
		public int gunVariation;
		public float shootDelay;

		bool shootReady;

		
		float cooldown;

		private AudioSource gunAud;
		private CameraController cc;
		private CameraFrustumTargeter targeter;
		public GunControl gc;

	}
}
