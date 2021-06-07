package com.appium.task;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.List;
import java.util.concurrent.TimeUnit;

import org.apache.commons.exec.ExecuteException;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.testng.Assert;
import org.testng.annotations.BeforeSuite;
import org.testng.annotations.Test;

import io.appium.java_client.MobileElement;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.remote.MobileCapabilityType;
public class AppTest {
  public static URL url;
  public static DesiredCapabilities capabilities;
  public static AndroidDriver<MobileElement> driver;

  @BeforeSuite
  public void setupAppium() throws MalformedURLException {

    final String URL_STRING = "http://127.0.0.1:4723/wd/hub";
    url = new URL(URL_STRING);

    capabilities = new DesiredCapabilities();
    capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "emulator-5556");
    System.out.println( "Test Starting" );
    capabilities.setCapability(MobileCapabilityType.APP, "https://www.browserstack.com/app-automate/sample-apps/android/WikipediaSample.apk");
    capabilities.setCapability(MobileCapabilityType.NO_RESET, true);
    capabilities.setCapability(MobileCapabilityType.AUTOMATION_NAME, "UiAutomator2");

    driver = new AndroidDriver<MobileElement>(url, capabilities);
    driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);
    driver.resetApp();
  }

  @Test (enabled=true) public void getCeraWikipage() throws InterruptedException {
    List<MobileElement> imageViews = (List<MobileElement>) driver.findElementsByClassName("android.widget.ImageView");
    imageViews.get(0).click();
    List<MobileElement> editTexts = (List<MobileElement>) driver.findElementsByClassName("android.widget.EditText");
    editTexts.get(0).sendKeys("Cera");
    MobileElement pageTitle = (MobileElement) driver.findElementById("org.wikipedia.alpha:id/page_list_item_title");
    pageTitle.click();
    try {
      List<MobileElement> textViews = (List<MobileElement>) driver.findElementsByClassName("android.widget.TextView");
      Assert.assertEquals(textViews.get(2).getText(), "home care");
    } catch (Exception E) {
      System.out.println( "Text not found " + E );
      throw E;
    } 
    finally {
    }
    driver.resetApp();
  }
  // Negative Scenario
  // @Test (enabled=true) public void negativeScenario() throws InterruptedException {}
}