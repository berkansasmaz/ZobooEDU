import HomePage from 'components/pages/home-page'
import SoruCevapEkle from 'components/pages/soru-cevap-ekle';
import TestOl from 'components/pages/test-ol';
import TestIstatistik from 'components/pages/test-istatistik'
import SınavSonuc from 'components/pages/sinav-sonuc'

import Forbidden from 'components/root/forbidden';


export const routes = [
	{
    name: 'home',
    path: '/',
    component: HomePage,
    display: 'Anasayfa',
    icon: 'home'
  },
  {
    divider: true,
    path: ''
  },
  {
    name: 'soru-cevap-ekle',
    path: '/soru/ekle',
    component: SoruCevapEkle,
    display: 'Soru ekle',
    icon: 'plus'
  },
  {
    name: 'test-ol',
    path: '/test/ol/',
    component: TestOl,
    display: 'Test Ol',
    icon: 'pen'
  },
  {
    name: 'test-istatistik',
	path: '/test/istatistik',
	component: TestIstatistik,
	display: 'Test İstatistik',
	icon: 'chart-line',
	hidden: false
  },
  {
    name: 'sinav-sonuc',
	path: '/sinav/sonuc/:id',
	component: SınavSonuc,
	display: 'Sınav Sonuç',
	icon: 'chart-line',
	hidden: true
  },
  {
    divider: true,
    path: ''
  },
  {
    name: 'account-view',
    path: '/Identity/Account/Manage',
    display: 'Account',
    icon: 'user-circle'
  },
  {
    name: 'forbidden',
    path: '/forbidden',
    hidden: true,
    component: Forbidden
  }
];
