using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace projectUTS
{
    class Window : GameWindow
    {
        //Jennifer
        J_Mesh kubus = new J_Mesh();
        J_Mesh balok1 = new J_Mesh();
        J_Mesh balok2 = new J_Mesh();
        J_Mesh mini1 = new J_Mesh();
        J_Mesh mini2 = new J_Mesh();
        J_Mesh mini3 = new J_Mesh();
        J_Mesh mini4 = new J_Mesh();
        J_Mesh mini5 = new J_Mesh();
        J_Mesh mini6 = new J_Mesh();
        J_Mesh mini7 = new J_Mesh();
        J_Mesh mini8 = new J_Mesh();
        J_Mesh mini9 = new J_Mesh();
        J_Mesh mini10 = new J_Mesh();
        J_Mesh mini11 = new J_Mesh();
        J_Mesh mini12 = new J_Mesh();
        J_Mesh mini13 = new J_Mesh();
        J_Mesh mini14 = new J_Mesh();
        J_Mesh mini15 = new J_Mesh();
        J_Mesh mini16 = new J_Mesh();
        J_Mesh miniR1 = new J_Mesh();
        J_Mesh miniR2 = new J_Mesh();
        J_Mesh miniR3 = new J_Mesh();
        J_Mesh miniR4 = new J_Mesh();
        J_Mesh miniR5 = new J_Mesh();
        J_Mesh miniR6 = new J_Mesh();
        J_Mesh miniR7 = new J_Mesh();
        J_Mesh miniL1 = new J_Mesh();
        J_Mesh miniL2 = new J_Mesh();
        J_Mesh miniL3 = new J_Mesh();
        J_Mesh miniL4 = new J_Mesh();
        J_Mesh miniL5 = new J_Mesh();
        J_Mesh miniL6 = new J_Mesh();
        J_Mesh miniL7 = new J_Mesh();
        J_Mesh miniL8 = new J_Mesh();
        J_EllipticCylinder pilar1 = new J_EllipticCylinder();
        J_EllipticCylinder pilar2 = new J_EllipticCylinder();
        J_EllipticCylinder pilar3 = new J_EllipticCylinder();
        J_EllipticCylinder pilar4 = new J_EllipticCylinder();
        J_EllipticPara cone1 = new J_EllipticPara();
        J_EllipticPara cone2 = new J_EllipticPara();
        J_EllipticPara cone3 = new J_EllipticPara();
        J_EllipticPara cone4 = new J_EllipticPara();
        J_Bezier bezier = new J_Bezier();

        //Clara
        C_Tabung badanKapal = new C_Tabung();
        C_Elliptic ekorKapal = new C_Elliptic();
        C_Ellipsoid kepalaKapal = new C_Ellipsoid();
        C_Balok baling1 = new C_Balok();
        C_Balok baling2 = new C_Balok();
        C_Balok badanAtas = new C_Balok();
        C_Balok tiang1 = new C_Balok();
        C_Balok tiang2 = new C_Balok();
        C_Ellipsoid ground = new C_Ellipsoid();
        C_Bezier pipe = new C_Bezier();
        C_Awan el1 = new C_Awan();
        C_Awan el2 = new C_Awan();
        C_Awan el3 = new C_Awan();
        C_Awan el4 = new C_Awan();
        C_Awan el5 = new C_Awan();
        C_Awan el6 = new C_Awan();
        C_Awan el7 = new C_Awan();
        C_Awan el8 = new C_Awan();

        C_Awan es1 = new C_Awan();
        C_Awan es2 = new C_Awan();
        C_Awan es3 = new C_Awan();
        C_Awan es4 = new C_Awan();
        C_Awan es5 = new C_Awan();
        C_Awan es6 = new C_Awan();
        C_Awan es7 = new C_Awan();
        C_Awan es8 = new C_Awan();

        C_Awan ei1 = new C_Awan();
        C_Awan ei2 = new C_Awan();
        C_Awan ei3 = new C_Awan();
        C_Awan ei4 = new C_Awan();
        C_Awan ei5 = new C_Awan();
        C_Awan ei6 = new C_Awan();
        C_Awan ei7 = new C_Awan();
        C_Awan ei8 = new C_Awan();

        //Freo
        F_Fountain fountain = new F_Fountain();
        F_TabungFountain tabung_fountain = new F_TabungFountain();
        F_Balok alasFountain = new F_Balok();
        F_BezierFountain bezier_fountain_1 = new F_BezierFountain();
        F_BezierFountain bezier_fountain_2 = new F_BezierFountain();

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        public void rotateAll(float _x, float _y, float _z)
        {
            kubus.rotate(_x, _y, _z);
            balok1.rotate(_x, _y, _z);
            balok2.rotate(_x, _y, _z);
            pilar1.rotate(_x, _y, _z);
            pilar2.rotate(_x, _y, _z);
            pilar3.rotate(_x, _y, _z);
            pilar4.rotate(_x, _y, _z);
            cone1.rotate(_x, _y, _z);
            cone2.rotate(_x, _y, _z);
            cone3.rotate(_x, _y, _z);
            cone4.rotate(_x, _y, _z);

            mini1.rotate(_x, _y, _z);
            mini2.rotate(_x, _y, _z);
            mini3.rotate(_x, _y, _z);
            mini4.rotate(_x, _y, _z);
            mini5.rotate(_x, _y, _z);
            mini6.rotate(_x, _y, _z);
            mini7.rotate(_x, _y, _z);
            mini8.rotate(_x, _y, _z);

            mini9.rotate(_x, _y, _z);
            mini10.rotate(_x, _y, _z);
            mini11.rotate(_x, _y, _z);
            mini12.rotate(_x, _y, _z);
            mini13.rotate(_x, _y, _z);
            mini14.rotate(_x, _y, _z);
            mini15.rotate(_x, _y, _z);
            mini16.rotate(_x, _y, _z);

            miniR1.rotate(_x, _y, _z);
            miniR2.rotate(_x, _y, _z);
            miniR3.rotate(_x, _y, _z);
            miniR4.rotate(_x, _y, _z);
            miniR5.rotate(_x, _y, _z);
            miniR6.rotate(_x, _y, _z);
            miniR7.rotate(_x, _y, _z);

            miniL1.rotate(_x, _y, _z);
            miniL2.rotate(_x, _y, _z);
            miniL3.rotate(_x, _y, _z);
            miniL4.rotate(_x, _y, _z);
            miniL5.rotate(_x, _y, _z);
            miniL6.rotate(_x, _y, _z);
            miniL7.rotate(_x, _y, _z);
            miniL8.rotate(_x, _y, _z);
            bezier.rotate(_x, _y, _z);

            badanKapal.rotate(_x, _y, _z);
            ekorKapal.rotate(_x, _y, _z);
            kepalaKapal.rotate(_x, _y, _z);
            baling1.rotate(_x, _y, _z);
            baling2.rotate(_x, _y, _z);
            badanAtas.rotate(_x, _y, _z);
            tiang1.rotate(_x, _y, _z);
            tiang2.rotate(_x, _y, _z);
            ground.rotate(_x, _y, _z);
        }

        protected override void OnLoad()
        {
            GL.ClearColor(0.294f, 0.580f, 0.96f, 1.0f);

            ground.createGroundVertices(0.0f, -0.5f, 0.0f, 1.5f, 0.07f, 1.5f);
            ground.setGround();

            //jennifer
            kubus.createBox(0.0f, 0.0f, 0.0f, 0.2f) ; 
            kubus.setupObject();
            kubus.setupElement();
            kubus.translate(0.0f, 0.0495f, 0.055f);
            //balok
            balok1.createBalok(-0.06f, 1.645f, 0.7f); 
            balok1.setupBalok();
            balok1.setupElement();
            balok1.translate(0.0f, 0.2f, 0.0f);
            balok2.createBalok(0.06f, 1.645f, 0.7f);
            balok2.setupBalok();
            balok2.setupElement();
            balok2.translate(0.0f, 0.2f, 0.0f);
            //kubus kecil
            mini1.createBox(-0.34f, 2.5f, 0.81f, 0.05f);
            mini1.setupMiniObject();
            mini1.setupElement();
            mini2.createBox(-0.24f, 2.5f, 0.81f, 0.05f);
            mini2.setupMiniObject();
            mini2.setupElement();
            mini3.createBox(-0.14f, 2.5f, 0.81f, 0.05f);
            mini3.setupMiniObject();
            mini3.setupElement();
            mini4.createBox(-0.04f, 2.5f, 0.81f, 0.05f);
            mini4.setupMiniObject();
            mini4.setupElement();
            mini5.createBox(0.06f, 2.5f, 0.81f, 0.05f);
            mini5.setupMiniObject();
            mini5.setupElement();
            mini6.createBox(0.16f, 2.5f, 0.81f, 0.05f);
            mini6.setupMiniObject();
            mini6.setupElement();
            mini7.createBox(0.26f, 2.5f, 0.81f, 0.05f);
            mini7.setupMiniObject();
            mini7.setupElement();
            mini8.createBox(0.36f, 2.5f, 0.81f, 0.05f);
            mini8.setupMiniObject();
            mini8.setupElement();
            mini9.createBox(-0.34f, 2.5f, 0.077f, 0.05f);
            mini9.setupMiniObject();
            mini9.setupElement();
            mini10.createBox(-0.24f, 2.5f, 0.077f, 0.05f);
            mini10.setupMiniObject();
            mini10.setupElement();
            mini11.createBox(-0.14f, 2.5f, 0.077f, 0.05f);
            mini11.setupMiniObject();
            mini11.setupElement();
            mini12.createBox(-0.04f, 2.5f, 0.077f, 0.05f);
            mini12.setupMiniObject();
            mini12.setupElement();
            mini13.createBox(0.06f, 2.5f, 0.077f, 0.05f);
            mini13.setupMiniObject();
            mini13.setupElement();
            mini14.createBox(0.16f, 2.5f, 0.077f, 0.05f);
            mini14.setupMiniObject();
            mini14.setupElement();
            mini15.createBox(0.26f, 2.5f, 0.077f, 0.05f);
            mini15.setupMiniObject();
            mini15.setupElement();
            mini16.createBox(0.36f, 2.5f, 0.077f, 0.05f);
            mini16.setupMiniObject();
            mini16.setupElement();
            miniR1.createBox(0.37f, 2.5f, 0.71f, 0.05f);
            miniR1.setupMiniObject();
            miniR1.setupElement();
            miniR2.createBox(0.37f, 2.5f, 0.61f, 0.05f);
            miniR2.setupMiniObject();
            miniR2.setupElement();
            miniR3.createBox(0.37f, 2.5f, 0.51f, 0.05f);
            miniR3.setupMiniObject();
            miniR3.setupElement();
            miniR4.createBox(0.37f, 2.5f, 0.41f, 0.05f);
            miniR4.setupMiniObject();
            miniR4.setupElement();
            miniR5.createBox(0.37f, 2.5f, 0.31f, 0.05f);
            miniR5.setupMiniObject();
            miniR5.setupElement();
            miniR6.createBox(0.37f, 2.5f, 0.21f, 0.05f);
            miniR6.setupMiniObject();
            miniR6.setupElement();
            miniR7.createBox(0.37f, 2.5f, 0.11f, 0.05f);
            miniR7.setupMiniObject();
            miniR7.setupElement();
            miniL1.createBox(-0.37f, 2.5f, 0.71f, 0.05f);
            miniL1.setupMiniObject();
            miniL1.setupElement();
            miniL2.createBox(-0.37f, 2.5f, 0.61f, 0.05f);
            miniL2.setupMiniObject();
            miniL2.setupElement();
            miniL3.createBox(-0.37f, 2.5f, 0.51f, 0.05f);
            miniL3.setupMiniObject();
            miniL3.setupElement();
            miniL4.createBox(-0.37f, 2.5f, 0.41f, 0.05f);
            miniL4.setupMiniObject();
            miniL4.setupElement();
            miniL5.createBox(-0.37f, 2.5f, 0.31f, 0.05f);
            miniL5.setupMiniObject();
            miniL5.setupElement();
            miniL6.createBox(-0.37f, 2.5f, 0.21f, 0.05f);
            miniL6.setupMiniObject();
            miniL6.setupElement();
            miniL7.createBox(-0.37f, 2.5f, 0.11f, 0.05f);
            miniL7.setupMiniObject();
            miniL7.setupElement();
            //pilar (tabung)
            pilar1.createEllipticCylinder(-0.5f, -0.42f, -4.4f);
            pilar1.setupObject();
            pilar2.createEllipticCylinder(0.5f, -0.42f, -4.4f);
            pilar2.setupObject();
            pilar3.createEllipticCylinder(-0.5f, 0.42f, -4.4f);
            pilar3.setupObject();
            pilar4.createEllipticCylinder(0.5f, 0.42f, -4.4f);
            pilar4.setupObject();
            //cone
            cone1.createElipticParaboloid(-0.5f, -0.4f, -5.8f);
            cone1.setupObject();
            cone2.createElipticParaboloid(0.5f, -0.4f, -5.8f);
            cone2.setupObject();
            cone3.createElipticParaboloid(-0.5f, 0.4f, -5.8f);
            cone3.setupObject();
            cone4.createElipticParaboloid(0.5f, 0.4f, -5.8f);
            cone4.setupObject();
            //bezier
            bezier.addPoint(-0.106f, -0.24f, 0.4f);
            bezier.addPoint(-0.106f, -0.116f, 0.4f);
            bezier.addPoint(0.0f, 0.05f, 0.4f);
            bezier.addPoint(0.106f, -0.116f, 0.4f);
            bezier.addPoint(0.106f, -0.24f, 0.4f);
            bezier.createBezier(0.01f, 0.01f, 0.01f);
            bezier.setupObject();

            //clara
            badanKapal.createTabungVertices();
            badanKapal.setTabung();
            ekorKapal.createEllipticVertices();
            ekorKapal.setElliptic();
            kepalaKapal.createEllipsoidVertices(); 
            kepalaKapal.setEllipsoid();
            baling1.createBalok(0.99f, -1.373f, 0f, 0.02f, 0.15f, 0.03f);
            baling1.setBaling();
            baling2.createBalok(0.99f, -1.373f, 0f, 0.02f, 0.03f, 0.15f);
            baling2.setBaling();
            badanAtas.createBalok(0f, -0.98f, 0f, 0.2f, 0.09f, 0.13f);
            badanAtas.setBalok();
            tiang1.createBalok(0f, -0.9f, 0f, 0.01f, 0.005f, 0.20f);
            tiang1.setBalok();
            tiang2.createBalok(0.05f, -0.9f, 0f, 0.01f, 0.005f, 0.22f); 
            tiang2.setBalok();
            pipe.addPoint(-0.038f, -0.546f, 0.0f);
            pipe.addPoint(-0.044f, -0.504f, 0.0f);
            pipe.addPoint(-0.084f, -0.502f, 0.0f);
            pipe.createBezier(0.003f, 0.003f, 0.003f);
            pipe.setupObject();
            el1.createElAwanVertices(0.4f, 1.19f, 0.29f, 0.09f, 0.072f, 0.09f);//( , atas/bawah(+/-) , kiri/kanan(-/+) , )
            el1.setAwan();
            el2.createElAwanVertices(0.4f, 1.158f, 0.17f, 0.064f, 0.06f, 0.064f);
            el2.setAwan();
            el3.createElAwanVertices(0.4f, 1.25f, 0.43f, 0.12f, 0.12f, 0.12f);
            el3.setAwan();
            el4.createElAwanVertices(0.4f, 1.155f, 0.44f, 0.085f, 0.085f, 0.085f);
            el4.setAwan();
            el5.createElAwanVertices(0.4f, 1.25f, 0.6f, 0.07f, 0.07f, 0.07f);
            el5.setAwan();
            el6.createElAwanVertices(0.4f, 1.13f, 0.57f, 0.08f, 0.08f, 0.08f);
            el6.setAwan();
            el7.createElAwanVertices(0.4f, 1.142f, 0.85f, 0.059f, 0.059f, 0.059f);
            el7.setAwan();
            el8.createElAwanVertices(0.4f, 1.157f, 0.72f, 0.11f, 0.11f, 0.11f);
            el8.setAwan();
            es1.createElAwanVertices(0.4f, 1.255f, -0.39f, 0.08f, 0.08f, 0.08f);
            es1.setAwan();
            es2.createElAwanVertices(0.4f, 1.158f, -0.36f, 0.09f, 0.08f, 0.09f);
            es2.setAwan();
            es3.createElAwanVertices(0.4f, 1.2f, -0.49f, 0.058f, 0.058f, 0.058f);
            es3.setAwan();
            es4.createElAwanVertices(0.4f, 1.155f, -0.56f, 0.05f, 0.05f, 0.05f);
            es4.setAwan();
            es5.createElAwanVertices(0.4f, 1.25f, -0.6f, 0.07f, 0.07f, 0.07f);
            es5.setAwan();
            es6.createElAwanVertices(0.4f, 1.27f, -0.49f, 0.043f, 0.043f, 0.043f);
            es6.setAwan();
            es7.createElAwanVertices(0.4f, 1.142f, -0.49f, 0.049f, 0.049f, 0.049f);
            es7.setAwan();
            es8.createElAwanVertices(0.4f, 1.157f, -0.65f, 0.07f, 0.07f, 0.07f);
            es8.setAwan();
            ei1.createElAwanVertices(0.4f, 1.0f, -1.45f, 0.1f, 0.065f, 0.1f);
            ei1.setAwan();
            ei2.createElAwanVertices(0.4f, 1.11f, -1.37f, 0.089f, 0.089f, 0.089f);
            ei2.setAwan();
            ei3.createElAwanVertices(0.4f, 1.15f, -1.25f, 0.058f, 0.058f, 0.058f);
            ei3.setAwan();
            ei4.createElAwanVertices(0.4f, 1.22f, -1.12f, 0.129f, 0.129f, 0.129f);
            ei4.setAwan();
            ei5.createElAwanVertices(0.4f, 1.13f, -0.99f, 0.079f, 0.079f, 0.079f);
            ei5.setAwan();
            ei6.createElAwanVertices(0.4f, 1.0f, -1.26f, 0.09f, 0.132f, 0.132f);
            ei6.setAwan();
            ei7.createElAwanVertices(0.4f, 1.03f, -1.09f, 0.11f, 0.11f, 0.11f);
            ei7.setAwan();
            ei8.createElAwanVertices(0.4f, 1.0f, -0.94f, 0.085f, 0.059f, 0.085f);
            ei8.setAwan();

            //freo
            fountain.createfountain1(-6.0f, 0.2f, -0.2f);        // fountain 1 (bawah)
            fountain.createfountain2(-6.0f, 0.2f, -0.2f);        // fountain 2 (tengah)
            fountain.createfountain3(-6.0f, 0.2f, -0.2f);        // fountain 3 (atas)
            tabung_fountain.createtabungfountain1(7.47f, -0.05f, -1.85f);   // tabung fountain 1
            tabung_fountain.createtabungfountain2(7.47f, -0.05f, -1.75f);    // tabung fountain 2
            tabung_fountain.createtabungfountain3(7.47f, -0.05f, -1.75f);    // tabung fountain 3
            bezier_fountain_1.addPoint(-0.714f, 0.105f, 0.0f);
            bezier_fountain_1.addPoint(-0.694f, 0.205f, 0.0f);
            bezier_fountain_1.addPoint(-0.634f, 0.245f, 0.0f);
            bezier_fountain_1.addPoint(-0.598f, 0.134f, 0.0f);
            bezier_fountain_1.addPoint(-0.588f, 0.022f, 0.0f);
            bezier_fountain_2.addPoint(-0.462f, 0.105f, 0.0f);
            bezier_fountain_2.addPoint(-0.482f, 0.205f, 0.0f);
            bezier_fountain_2.addPoint(-0.542f, 0.245f, 0.0f);
            bezier_fountain_2.addPoint(-0.578f, 0.134f, 0.0f);
            bezier_fountain_2.addPoint(-0.588f, 0.022f, 0.0f);
            bezier_fountain_1.createBezierFountain(0.003f, 0.003f, 0.003f);    // bezier atas fountain 3
            bezier_fountain_2.createBezierFountain(0.003f, 0.003f, 0.003f);    // bezier atas fountain 3
            alasFountain.createBalok(-0.61f, -0.3f, 0.02f, 0.17f, 0.1f, 0.1f);
            alasFountain.setBalok();         
            fountain.OnLoad();
            tabung_fountain.OnLoad();
            bezier_fountain_1.SetBezierFountain();
            bezier_fountain_2.SetBezierFountain();

            rotateAll(5.5f, -6.9f, 0.0f);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            ground.renderGround();

            //jennifer
            
            miniR1.rendermini();
            miniR2.rendermini();
            miniR3.rendermini();
            miniR4.rendermini();
            miniR5.rendermini();
            miniR6.rendermini();
            miniR7.rendermini();
            miniL1.rendermini();
            miniL2.rendermini();
            miniL3.rendermini();
            miniL4.rendermini();
            miniL5.rendermini();
            miniL6.rendermini();
            miniL7.rendermini();
            pilar1.render();
            pilar2.render();
            kubus.render(); 
            mini1.rendermini();
            mini2.rendermini();
            mini3.rendermini();
            mini4.rendermini();
            mini5.rendermini();
            mini6.rendermini();
            mini7.rendermini();
            mini8.rendermini();
            mini9.rendermini();
            mini10.rendermini();
            mini11.rendermini();
            mini12.rendermini();
            mini13.rendermini();
            mini14.rendermini();
            mini15.rendermini();
            mini16.rendermini();
            pilar3.render();
            pilar4.render();
            balok1.renderBalok();
            balok2.renderBalok();
            bezier.render();
            cone1.render();
            cone2.render();
            cone3.render();
            cone4.render();

            //clara
            badanKapal.renderTabung();
            ekorKapal.renderElliptic();
            kepalaKapal.renderEllipsoid();
            baling1.renderBaling();
            baling2.renderBaling();
            badanAtas.renderBalok();
            tiang1.renderBalok();
            tiang2.renderBalok();
            pipe.render();
            el1.renderAwan();
            el2.renderAwan();
            el3.renderAwan();
            el4.renderAwan();
            el5.renderAwan();
            el6.renderAwan();
            el7.renderAwan();
            el8.renderAwan();
            es1.renderAwan();
            es2.renderAwan();
            es3.renderAwan();
            es4.renderAwan();
            es5.renderAwan();
            es6.renderAwan();
            es7.renderAwan();
            es8.renderAwan();
            ei1.renderAwan();
            ei2.renderAwan();
            ei3.renderAwan();
            ei4.renderAwan();
            ei5.renderAwan();
            ei6.renderAwan();
            ei7.renderAwan();
            ei8.renderAwan();

            //freo
            tabung_fountain.RenderFrame();
            fountain.RenderFrame();
            alasFountain.renderBalok(); 
            bezier_fountain_1.RenderBezier();
            bezier_fountain_2.RenderBezier();

            SwapBuffers();
            base.OnRenderFrame(args);
        }
    }
}