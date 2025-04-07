using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamInventory
	{
		public const string Version = "STEAMINVENTORY_INTERFACE_V003";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamInventory_v003", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamInventory_v003();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerInventory_v003", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerInventory_v003();
		/// Construct use accessor to find interface
		public ISteamInventory( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamInventory_v003();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerInventory_v003();
			}
		}
		public ISteamInventory( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamInventory_GetResultStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetResultStatus", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamInventory_GetResultStatus( IntPtr self, SteamInventoryResult_t resultHandle );
		#endregion
		internal EResult GetResultStatus( SteamInventoryResult_t resultHandle )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetResultStatus( Self, resultHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetResultItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetResultItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetResultItems( IntPtr self, SteamInventoryResult_t resultHandle, SteamItemDetails_t* pOutItemsArray, ref uint punOutItemsArraySize );
		#endregion
		internal bool GetResultItems( SteamInventoryResult_t resultHandle, SteamItemDetails_t* pOutItemsArray, ref uint punOutItemsArraySize )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetResultItems( Self, resultHandle, pOutItemsArray, ref punOutItemsArraySize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetResultItemProperty
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetResultItemProperty", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetResultItemProperty( IntPtr self, SteamInventoryResult_t resultHandle, uint unItemIndex, IntPtr pchPropertyName, IntPtr pchValueBuffer, ref uint punValueBufferSizeOut );
		#endregion
		internal bool GetResultItemProperty( SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			using var mem__pchValueBuffer = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamInventory_GetResultItemProperty( Self, resultHandle, unItemIndex, str__pchPropertyName.Pointer, mem__pchValueBuffer.Ptr, ref punValueBufferSizeOut );
			pchValueBuffer = Utility.MemoryToString( mem__pchValueBuffer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetResultTimestamp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetResultTimestamp", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamInventory_GetResultTimestamp( IntPtr self, SteamInventoryResult_t resultHandle );
		#endregion
		internal uint GetResultTimestamp( SteamInventoryResult_t resultHandle )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetResultTimestamp( Self, resultHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_CheckResultSteamID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_CheckResultSteamID", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_CheckResultSteamID( IntPtr self, SteamInventoryResult_t resultHandle, SteamId steamIDExpected );
		#endregion
		internal bool CheckResultSteamID( SteamInventoryResult_t resultHandle, SteamId steamIDExpected )
		{
			var returnValue = _SteamAPI_ISteamInventory_CheckResultSteamID( Self, resultHandle, steamIDExpected );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_DestroyResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_DestroyResult", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInventory_DestroyResult( IntPtr self, SteamInventoryResult_t resultHandle );
		#endregion
		internal void DestroyResult( SteamInventoryResult_t resultHandle )
		{
			_SteamAPI_ISteamInventory_DestroyResult( Self, resultHandle );
		}
		
		#region SteamAPI_ISteamInventory_GetAllItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetAllItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetAllItems( IntPtr self, ref SteamInventoryResult_t pResultHandle );
		#endregion
		internal bool GetAllItems( ref SteamInventoryResult_t pResultHandle )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetAllItems( Self, ref pResultHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetItemsByID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetItemsByID", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetItemsByID( IntPtr self, ref SteamInventoryResult_t pResultHandle, ref SteamItemInstanceID_t pInstanceIDs, uint unCountInstanceIDs );
		#endregion
		internal bool GetItemsByID( ref SteamInventoryResult_t pResultHandle, ref SteamItemInstanceID_t pInstanceIDs, uint unCountInstanceIDs )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetItemsByID( Self, ref pResultHandle, ref pInstanceIDs, unCountInstanceIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SerializeResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SerializeResult", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_SerializeResult( IntPtr self, SteamInventoryResult_t resultHandle, IntPtr pOutBuffer, ref uint punOutBufferSize );
		#endregion
		internal bool SerializeResult( SteamInventoryResult_t resultHandle, IntPtr pOutBuffer, ref uint punOutBufferSize )
		{
			var returnValue = _SteamAPI_ISteamInventory_SerializeResult( Self, resultHandle, pOutBuffer, ref punOutBufferSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_DeserializeResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_DeserializeResult", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_DeserializeResult( IntPtr self, ref SteamInventoryResult_t pOutResultHandle, IntPtr pBuffer, uint unBufferSize, [ MarshalAs( UnmanagedType.U1 ) ] bool bRESERVED_MUST_BE_FALSE );
		#endregion
		internal bool DeserializeResult( ref SteamInventoryResult_t pOutResultHandle, IntPtr pBuffer, uint unBufferSize, [ MarshalAs( UnmanagedType.U1 ) ] bool bRESERVED_MUST_BE_FALSE )
		{
			var returnValue = _SteamAPI_ISteamInventory_DeserializeResult( Self, ref pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GenerateItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GenerateItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GenerateItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t* pArrayItemDefs, uint* punArrayQuantity, uint unArrayLength );
		#endregion
		internal bool GenerateItems( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t* pArrayItemDefs, uint* punArrayQuantity, uint unArrayLength )
		{
			var returnValue = _SteamAPI_ISteamInventory_GenerateItems( Self, ref pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GrantPromoItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GrantPromoItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GrantPromoItems( IntPtr self, ref SteamInventoryResult_t pResultHandle );
		#endregion
		internal bool GrantPromoItems( ref SteamInventoryResult_t pResultHandle )
		{
			var returnValue = _SteamAPI_ISteamInventory_GrantPromoItems( Self, ref pResultHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_AddPromoItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItem", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_AddPromoItem( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef );
		#endregion
		internal bool AddPromoItem( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef )
		{
			var returnValue = _SteamAPI_ISteamInventory_AddPromoItem( Self, ref pResultHandle, itemDef );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_AddPromoItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_AddPromoItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t* pArrayItemDefs, uint unArrayLength );
		#endregion
		internal bool AddPromoItems( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t* pArrayItemDefs, uint unArrayLength )
		{
			var returnValue = _SteamAPI_ISteamInventory_AddPromoItems( Self, ref pResultHandle, pArrayItemDefs, unArrayLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_ConsumeItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_ConsumeItem", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_ConsumeItem( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity );
		#endregion
		internal bool ConsumeItem( ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity )
		{
			var returnValue = _SteamAPI_ISteamInventory_ConsumeItem( Self, ref pResultHandle, itemConsume, unQuantity );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_ExchangeItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_ExchangeItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_ExchangeItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t* pArrayGenerate, uint* punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t* pArrayDestroy, uint* punArrayDestroyQuantity, uint unArrayDestroyLength );
		#endregion
		internal bool ExchangeItems( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t* pArrayGenerate, uint* punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t* pArrayDestroy, uint* punArrayDestroyQuantity, uint unArrayDestroyLength )
		{
			var returnValue = _SteamAPI_ISteamInventory_ExchangeItems( Self, ref pResultHandle, pArrayGenerate, punArrayGenerateQuantity, unArrayGenerateLength, pArrayDestroy, punArrayDestroyQuantity, unArrayDestroyLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_TransferItemQuantity
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_TransferItemQuantity", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_TransferItemQuantity( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest );
		#endregion
		internal bool TransferItemQuantity( ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest )
		{
			var returnValue = _SteamAPI_ISteamInventory_TransferItemQuantity( Self, ref pResultHandle, itemIdSource, unQuantity, itemIdDest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SendItemDropHeartbeat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SendItemDropHeartbeat", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInventory_SendItemDropHeartbeat( IntPtr self );
		#endregion
		internal void SendItemDropHeartbeat()
		{
			_SteamAPI_ISteamInventory_SendItemDropHeartbeat( Self );
		}
		
		#region SteamAPI_ISteamInventory_TriggerItemDrop
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_TriggerItemDrop", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_TriggerItemDrop( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition );
		#endregion
		internal bool TriggerItemDrop( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition )
		{
			var returnValue = _SteamAPI_ISteamInventory_TriggerItemDrop( Self, ref pResultHandle, dropListDefinition );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_TradeItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_TradeItems", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_TradeItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamId steamIDTradePartner, SteamItemInstanceID_t* pArrayGive, uint* pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t* pArrayGet, uint* pArrayGetQuantity, uint nArrayGetLength );
		#endregion
		internal bool TradeItems( ref SteamInventoryResult_t pResultHandle, SteamId steamIDTradePartner, SteamItemInstanceID_t* pArrayGive, uint* pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t* pArrayGet, uint* pArrayGetQuantity, uint nArrayGetLength )
		{
			var returnValue = _SteamAPI_ISteamInventory_TradeItems( Self, ref pResultHandle, steamIDTradePartner, pArrayGive, pArrayGiveQuantity, nArrayGiveLength, pArrayGet, pArrayGetQuantity, nArrayGetLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_LoadItemDefinitions
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_LoadItemDefinitions", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_LoadItemDefinitions( IntPtr self );
		#endregion
		internal bool LoadItemDefinitions()
		{
			var returnValue = _SteamAPI_ISteamInventory_LoadItemDefinitions( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetItemDefinitionIDs
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionIDs", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetItemDefinitionIDs( IntPtr self, SteamItemDef_t* pItemDefIDs, ref uint punItemDefIDsArraySize );
		#endregion
		internal bool GetItemDefinitionIDs( SteamItemDef_t* pItemDefIDs, ref uint punItemDefIDsArraySize )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetItemDefinitionIDs( Self, pItemDefIDs, ref punItemDefIDsArraySize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetItemDefinitionProperty
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionProperty", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetItemDefinitionProperty( IntPtr self, SteamItemDef_t iDefinition, IntPtr pchPropertyName, IntPtr pchValueBuffer, ref uint punValueBufferSizeOut );
		#endregion
		internal bool GetItemDefinitionProperty( SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			using var mem__pchValueBuffer = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamInventory_GetItemDefinitionProperty( Self, iDefinition, str__pchPropertyName.Pointer, mem__pchValueBuffer.Ptr, ref punValueBufferSizeOut );
			pchValueBuffer = Utility.MemoryToString( mem__pchValueBuffer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs( IntPtr self, SteamId steamID );
		#endregion
		internal SteamAPICall_t RequestEligiblePromoItemDefinitionsIDs( SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs( Self, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs( IntPtr self, SteamId steamID, SteamItemDef_t* pItemDefIDs, ref uint punItemDefIDsArraySize );
		#endregion
		internal bool GetEligiblePromoItemDefinitionIDs( SteamId steamID, SteamItemDef_t* pItemDefIDs, ref uint punItemDefIDsArraySize )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs( Self, steamID, pItemDefIDs, ref punItemDefIDsArraySize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_StartPurchase
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_StartPurchase", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamInventory_StartPurchase( IntPtr self, SteamItemDef_t* pArrayItemDefs, uint* punArrayQuantity, uint unArrayLength );
		#endregion
		internal SteamAPICall_t StartPurchase( SteamItemDef_t* pArrayItemDefs, uint* punArrayQuantity, uint unArrayLength )
		{
			var returnValue = _SteamAPI_ISteamInventory_StartPurchase( Self, pArrayItemDefs, punArrayQuantity, unArrayLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_RequestPrices
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_RequestPrices", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamInventory_RequestPrices( IntPtr self );
		#endregion
		internal SteamAPICall_t RequestPrices()
		{
			var returnValue = _SteamAPI_ISteamInventory_RequestPrices( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetNumItemsWithPrices
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetNumItemsWithPrices", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamInventory_GetNumItemsWithPrices( IntPtr self );
		#endregion
		internal uint GetNumItemsWithPrices()
		{
			var returnValue = _SteamAPI_ISteamInventory_GetNumItemsWithPrices( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetItemsWithPrices
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetItemsWithPrices", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetItemsWithPrices( IntPtr self, SteamItemDef_t* pArrayItemDefs, ulong* pCurrentPrices, ulong* pBasePrices, uint unArrayLength );
		#endregion
		internal bool GetItemsWithPrices( SteamItemDef_t* pArrayItemDefs, ulong* pCurrentPrices, ulong* pBasePrices, uint unArrayLength )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetItemsWithPrices( Self, pArrayItemDefs, pCurrentPrices, pBasePrices, unArrayLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_GetItemPrice
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_GetItemPrice", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_GetItemPrice( IntPtr self, SteamItemDef_t iDefinition, ref ulong pCurrentPrice, ref ulong pBasePrice );
		#endregion
		internal bool GetItemPrice( SteamItemDef_t iDefinition, ref ulong pCurrentPrice, ref ulong pBasePrice )
		{
			var returnValue = _SteamAPI_ISteamInventory_GetItemPrice( Self, iDefinition, ref pCurrentPrice, ref pBasePrice );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_StartUpdateProperties
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_StartUpdateProperties", CallingConvention = Platform.CC ) ]
		internal static extern SteamInventoryUpdateHandle_t _SteamAPI_ISteamInventory_StartUpdateProperties( IntPtr self );
		#endregion
		internal SteamInventoryUpdateHandle_t StartUpdateProperties()
		{
			var returnValue = _SteamAPI_ISteamInventory_StartUpdateProperties( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_RemoveProperty
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_RemoveProperty", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_RemoveProperty( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, IntPtr pchPropertyName );
		#endregion
		internal bool RemoveProperty( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			var returnValue = _SteamAPI_ISteamInventory_RemoveProperty( Self, handle, nItemID, str__pchPropertyName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SetPropertyString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyString", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_SetPropertyString( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, IntPtr pchPropertyName, IntPtr pchPropertyValue );
		#endregion
		internal bool SetProperty( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, string pchPropertyValue )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			using var str__pchPropertyValue = new Utf8StringToNative( pchPropertyValue );
			var returnValue = _SteamAPI_ISteamInventory_SetPropertyString( Self, handle, nItemID, str__pchPropertyName.Pointer, str__pchPropertyValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SetPropertyBool
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyBool", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_SetPropertyBool( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, IntPtr pchPropertyName, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool SetProperty( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			var returnValue = _SteamAPI_ISteamInventory_SetPropertyBool( Self, handle, nItemID, str__pchPropertyName.Pointer, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SetPropertyInt64
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyInt64", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_SetPropertyInt64( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, IntPtr pchPropertyName, long nValue );
		#endregion
		internal bool SetProperty( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, long nValue )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			var returnValue = _SteamAPI_ISteamInventory_SetPropertyInt64( Self, handle, nItemID, str__pchPropertyName.Pointer, nValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SetPropertyFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_SetPropertyFloat( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, IntPtr pchPropertyName, float flValue );
		#endregion
		internal bool SetProperty( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, float flValue )
		{
			using var str__pchPropertyName = new Utf8StringToNative( pchPropertyName );
			var returnValue = _SteamAPI_ISteamInventory_SetPropertyFloat( Self, handle, nItemID, str__pchPropertyName.Pointer, flValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_SubmitUpdateProperties
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_SubmitUpdateProperties", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_SubmitUpdateProperties( IntPtr self, SteamInventoryUpdateHandle_t handle, ref SteamInventoryResult_t pResultHandle );
		#endregion
		internal bool SubmitUpdateProperties( SteamInventoryUpdateHandle_t handle, ref SteamInventoryResult_t pResultHandle )
		{
			var returnValue = _SteamAPI_ISteamInventory_SubmitUpdateProperties( Self, handle, ref pResultHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInventory_InspectItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInventory_InspectItem", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInventory_InspectItem( IntPtr self, ref SteamInventoryResult_t pResultHandle, IntPtr pchItemToken );
		#endregion
		internal bool InspectItem( ref SteamInventoryResult_t pResultHandle, string pchItemToken )
		{
			using var str__pchItemToken = new Utf8StringToNative( pchItemToken );
			var returnValue = _SteamAPI_ISteamInventory_InspectItem( Self, ref pResultHandle, str__pchItemToken.Pointer );
			return returnValue;
		}
		
	}
}
