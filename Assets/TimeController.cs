using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;

    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunLightIntensity;

    [SerializeField]
    private Light moonLight;

    [SerializeField]
    private float maxMoonLightIntensity;

    [SerializeField]
    private Gradient fogColor;

    private DateTime currentTime;

    private DateTime startOfDay;

    private TimeSpan sunriseTime;
    
    private TimeSpan sunsetTime;

    [SerializeField]
    private ParticleSystem fog1;

    [SerializeField]
    private ParticleSystem fog2;

    // Start is called before the first frame update
    void Start()
    {
        startOfDay = DateTime.Now.Date;
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    // Updates the text displaying the time of day
    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        
        

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }

        if(currentTime.ToString("HH:mm") == "23:30")
        {
            //Debug.Log("End of the day");
            SceneManager.LoadScene("EndDayScreen");
        }

        startOfDay = currentTime.Date;
    }

    // Rotates the sun around the game world over a timespan
    private void RotateSun()
    {
        float sunLightRotation;
        float moonLightRotation;

        //if daytime
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
            moonLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }
        //else if nighttime
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
            moonLightRotation = Mathf.Lerp(0, 180, (float)percentage);

        }

        

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
        moonLight.transform.rotation = Quaternion.AngleAxis(moonLightRotation, Vector3.right);
    }

    // Calculates the difference between two TimeSpan values
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }

    // Updates the ambient light and intensity of both the sun and moon light sources
    private void UpdateLightSettings()
    {
        // Updating Ambient Light
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
        
        // // Updating Fog
        TimeSpan timeElapsed = currentTime - startOfDay;
        float gradientPos = (float)timeElapsed.TotalMinutes / 1440;

      
        RenderSettings.fogColor = fogColor.Evaluate(gradientPos);
       
        RenderSettings.fogDensity = ( 0.08f + 0.4f * (float)Math.Sqrt(
            Mathf.Max( (float)Mathf.Cos(2.0f * (currentTime.Hour + currentTime.Minute/60.0f) *((float)Math.PI/24.0f)), 0)
        ) );
       
    }

    private void UpdateFog()
    {
        // ParticleSystem.MainModule fog1 = GetComponent<ParticleSystem>("Fog 1").main;
        // ParticleSystem.MainModule fog2 = GetComponent<ParticleSystem>("Fog 2").main;
        ParticleSystem.MainModule mainfog1 = GameObject.Find("Fog 1").GetComponent<ParticleSystem>().main;
        ParticleSystem.MainModule mainfog2 = GameObject.Find("Fog 2").GetComponent<ParticleSystem>().main;

         float opacity =( 0.08f + 255.0f * (float)Math.Sqrt(
            Mathf.Max( (float)Mathf.Cos(2.0f * (currentTime.Hour + currentTime.Minute/60.0f) *((float)Math.PI/24.0f)), 0)
        ) );

        mainfog1.startColor = new ParticleSystem.MinMaxGradient(new Color(221, 221, 221, opacity));
        mainfog2.startColor = new ParticleSystem.MinMaxGradient(new Color(221, 221, 221, opacity));
        // mainfog1.stopColor = new Color(1, 0, 1, opacity);
        // mainfog2.stopColor = new Color(1, 0, 1, opacity);

        // fog1.startColor.A=opacity;
        // fog1.stopColor.A=opacity;
        // fog2.startColor.A=opacity;
        // fog2.stopColor.A=opacity;
    }
}
